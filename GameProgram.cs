using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Timers;

namespace Tetirs
{
    
    public delegate void KeyDownEventHander(ConsoleKey key);
    class GameProgram
    {
        int[,] checkerboard = new int[22, 24];
        int score = 0;
        public int x = 1;
        public int y = 6;
       
        BaseShape mgr;
        BaseShape newmgr;
        object obj = new object();
       
        public event KeyDownEventHander KeyDown;
        public void KeyDownEvent(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                   break;
                case ConsoleKey.R:
                    ReStartGame();
                    break;
                case ConsoleKey.LeftArrow:
                    left(ref y);
                    lock (obj)
                    {
                        Getshape(mgr, x, y);
                        print();
                    }
                    break;
                case ConsoleKey.UpArrow:
                    mgr.transform(checkerboard);
                    break;
                case ConsoleKey.RightArrow:
                    right(ref y);
                    lock (obj)
                    {
                        Getshape(mgr, x, y);
                        print();
                    }
                    break;
                case ConsoleKey.DownArrow:
                   lock (obj)
                    {
                        Getshape(mgr, x, y);
                        print();
                    }
                    down(ref x);
                    break;
                default:
                    break;
            }
        }
        Thread keyDownThread;
        private void KeyDownThread()
        {
            while (true)
            {
                //子线程监听键盘按下，只要按下就触发事件
                KeyDown(Console.ReadKey(true).Key);//触发KeyDown事件
            }
        }
        public void StartGame()
        {
            //初始化键盘监听线程
            keyDownThread = new Thread(new ThreadStart(KeyDownThread));
            //注册键盘触发事件对应的函数
            KeyDown += new KeyDownEventHander(KeyDownEvent);
            score = 0;
            mgr = ShapeMgr.GetShape();
            newmgr = ShapeMgr.GetShape();
            //启动线程
            keyDownThread.Start();
            Getboard();
            //计时器
            System.Timers.Timer timer;
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Start();

        }
        //重新开始游戏
        public void ReStartGame()
        {
            for (int i = 0; i < 22; i++)
            {

                for (int n = 0; n < 24; n++)
                {
                    if (checkerboard[i, n] == 1 || checkerboard[i, n] == 2)
                    {
                        checkerboard[i, n] = 0;
                    }
                }
            }
            score = 0;
            Refresh(ref mgr, ref newmgr);
            print();
        }
        //刷新形状
        public void Refresh(ref BaseShape bs, ref BaseShape newbs)
        {

            bs = newbs;
            newbs = ShapeMgr.GetShape();
            x = 1;
            y = 6;
        }
        private void Timer_Elapsed(object Source, System.Timers.ElapsedEventArgs e)
        {
            lock (obj)
            {
                Getshape(mgr, x, y);
                if (GameOver())
                {
                    print();
                }
                down(ref x);               
            }
        }
        //墙
        public void Getboard(){
            for (int i = 0; i < 22; i++)
            {
                for (int n = 0; n < 24; n++)
                {
                    checkerboard[21, n] = 3;
                    checkerboard[0, n] = 3;
                    if (n>15&&n<24)
                    {
                        checkerboard[15, n] = 3;
                    }
                }
                checkerboard[i, 15] = 3;
                checkerboard[i, 0] = 3;
                checkerboard[i, 23] = 3;
            }

        }
        //形状赋给棋盘
        public void Getshape(BaseShape bs, int x, int y) {

                clear();
            
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (bs.element[i,j]!=0)
                        {
                            checkerboard[i + x, j + y] = bs.element[i, j];
                        }
                        
                    }
                }
            
            
        }
        //获取新的形状
        public void GetNextShape(BaseShape bs)
        {
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    checkerboard[i +8, j + 18] = bs.element[i, j];
                }
            }
        }
        //得分消除
        public void ScoreClear(int x)
        {
            
            for (int i = x; i > 1; i--)
            {
                for (int n = 14; n >0; n--)
                {
                    
                    checkerboard[i, n] = checkerboard[i-1, n];
                }
            }
            score++;
        }
        //判断得分
        public void GetScore() { 
            int h=0;
            
            for (int i =20; i >1; i--)
            {

                for (int n=14; n >0; n--)
                {
                    if (checkerboard[i,n]==2)
                    {
                        h++;
                    }
                   
                }
                if (h == 14)
                {
                    ScoreClear(i);
                }
                h = 0;
            }
            


        }
        //判断游戏是否结束
        public bool GameOver() {
            
                for (int n = 16; n > 0; n--)
                {
                    if (checkerboard[1, n] == 2&&checkerboard[0,n]==3)
                    {
                        return false;
                    }
                }
            
            return true;
        }
        //固定已落地的方块
        public void regular(){
            for (int i = 0; i < 22; i++)
            {

                for (int n = 0; n < 24; n++)
                {
                    if (checkerboard[i, n] == 1)
                    {
                        checkerboard[i, n] = 2;
                    }
                }
            }

        }

        //打印棋盘和形状
        public void print()
        {
            
            GetNextShape(newmgr);
            GetScore();
            string k = "■";
           
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("            输入Q退出，输入R重新开始            ");
            for (int i = 0; i < 22; i++)
            {
                
                for (int n = 0; n <24; n++)
                {
                    if (checkerboard[i, n] == 3)
                    {
                        Console.Write(k);

                    }
                    else if (checkerboard[i, n] == 1)
                        Console.Write(k);
                    else if (checkerboard[i, n] == 2)
                        Console.Write(k);
                    else if (i == 17 && n == 18)
                    {
                     
                        Console.Write("得分:{0,-3}", score);
                        n = n + 3;
                    }
                    else 
                    {
                        Console.Write("  ");
                    }
                   

                   

                }
                
                Console.Write("\n");
            }
            if (!GameOver())
            {
                Console.WriteLine("                  GAME OVER                     ");
                Console.WriteLine("             输入Q退出，输入R重新开始           ");
            }
            

        }
        //清除方块下降前已赋值的数组
        public void clear() {
            for (int i = 0; i < 22; i++)
            {

                for (int n = 0; n < 24; n++)
                {
                    if (checkerboard[i, n] == 1)
                    {
                        checkerboard[i, n] = 0;
                    }
                }
            }
            
        }
        //
       public void left(ref int y)
        {
    
            for (int i = 21; i > 0; i--)
            {
                for (int n = 1; n < 16; n++)
                {
                    if (checkerboard[i, n] == 1&&checkerboard[i,n-1]==0)
                    {
                        break;
                    }
                    if (checkerboard[i, n] == 1 && checkerboard[i, n - 1] != 0)
                    {
                        return;
                    }
                }
            }
            y--;
           
        }
        public void right(ref int y)
        {
            for (int i = 21; i > 0; i--)
            {
                for (int n = 16; n >1; n--)
                {
                    if (checkerboard[i, n] == 1 && checkerboard[i, n + 1] == 0)
                    {
                        break;
                    }
                    if (checkerboard[i, n] == 1 && checkerboard[i, n + 1] != 0)
                    {
                        return;
                    }
                }
            }
            y++;
        }

        public void down(ref int x) {
          
                for (int n = 1; n < 16; n++)
                {
                for (int i = 20; i > 1; i--)
                {
                    if (checkerboard[i, n] == 1 && checkerboard[i+1, n] == 0)
                    {
                        break;
                    }
                    if (checkerboard[i, n] == 1 && checkerboard[i+1, n ] != 0)
                    {
                        if (GameOver())
                        {
                        regular();
                        Refresh(ref mgr,ref   newmgr);
                        }
                        
                      
                        return;
                    }
                }
            }
            x++;
           
        }
       
    }

}
