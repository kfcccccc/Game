using System;
using System.Collections.Generic;
using System.Text;

namespace Tetirs
{
    //形状基类
    public abstract class BaseShape
    {
        public int x;
        public int y;
        public int[,] element = new int[4, 4];
        abstract public void transform(int[,] b);
        
        
    }
    //方块 
    public class Square : BaseShape
    {
        public Square()
        {
            element[0, 0] = 1;
            element[0, 1] = 1;
            element[1, 0] = 1;
            element[1, 1] = 1;
        }
        public override void transform(int[,] b)
        {
            return;
        }
    }
    //直线
    public class Line : BaseShape
    {
        public Line()
        {
            element[0, 0] = 1;
            element[0, 1] = 1;
            element[0, 2] = 1;
            element[0, 3] = 1;
        }
        public override void transform(int[,] b)
        {
            for (int i = 20; i > 0; i--)
            {
                for (int n = 16; n > 0; n--)
                {
                    if (b[i, n] == 1)
                    {
                        x = i;
                        y = n;

                    }
                }
            }
            if (element[0, 3] == 1&&b[x+1,y]==0&&b[x+2,y]==0 && b[x + 3, y] == 0)
            {
                
                element[0, 1] = 0;
                element[0, 2] = 0;
                element[0, 3] = 0;               
                element[1, 0] = 1;
                element[2, 0] = 1;
                element[3, 0] = 1;
            }
            else if (element[3,0] == 1 && b[x , y + 1] == 0 && b[x , y + 2] == 0 && b[x , y + 3] == 0)
            
            {
                element[1, 0] = 0;
                element[2, 0] = 0;
                element[3, 0] = 0;
                element[0, 1] = 1;
                element[0, 2] = 1;
                element[0, 3] = 1;
            }
            
        }
    }
    //左L
    public class leftL : BaseShape
    {
        public leftL()
        {
            element[0, 0] = 1;
            element[1, 0] = 1;
            element[1, 1] = 1;
            element[1, 2] = 1;
        }
        public override void transform(int[,] b)
        {
            for (int i = 20; i > 0; i--)
            {
                for (int n = 15; n > 0; n--)
                {
                    if (b[i, n] == 1)
                    {
                        x = i;
                        y = n;
                    }
                }
            }
            if (element[0, 0] == 1&&b[x,y+1]==0 && b[x, y + 2] == 0 && b[x+2, y + 1] == 0)
            {
                element[0, 0] = 0;
                element[1, 0] = 0;               
                element[1, 2] = 0;
                element[0, 1] = 1;
                element[0, 2] = 1;
                element[2, 1] = 1;
            }
            else if (element[0, 2] == 1&&b[x-1,y-1]==0 && b[x +1, y + 1] == 0 && b[x + 2, y + 1] == 0)
            {

                element[0, 1] = 0;
                element[0, 2] = 0;
                element[2, 1] = 0;
                element[1, 0] = 1;
                element[1, 2] = 1;
                element[2, 2] = 1;
            }
            else if (element[2, 2] == 1&&b[x+1,y+1]==0 && b[x -1, y ] == 0 && b[x - 1, y+1] == 0)
            {
                element[1, 0] = 0;
                element[1, 2] = 0;
                element[2, 2] = 0;                
                element[0, 1] = 1;
                element[2, 0] = 1;
                element[2, 1] = 1;
            }
            else if (element[2, 0] == 1&&b[x,y-1]==0 && b[x-1, y - 1] == 0 && b[x-1, y + 1] == 0)
            {
                element[0, 1] = 0;
                element[2, 0] = 0;
                element[2, 1] = 0;
                element[0, 0] = 1;
                element[1, 0] = 1;
                element[1, 2] = 1;
            }
        }
    }
    //T
    public class ShapeT : BaseShape
    {
        public ShapeT() {
            element[0, 1] = 1;
            element[1, 0] = 1;
            element[1, 1] = 1;
            element[1, 2] = 1;
        }
        public override void transform(int[,] b)
        {
           for (int i = 20; i >0; i--)
            {
                for (int n =16; n>0; n--)
                {
                    if (b[i,n]==1)
                    {
                        x = i;
                        y = n;
                        
                    }
                }
            }
            if (element[2, 1] == 0&&b[x+2,y]==0)
            {
                element[1, 0] = 0;
                element[2, 1] = 1;
            }
            else if (element[1, 0] == 0&&b[x+1,y-1]==0)
            {
                element[0, 1] = 0;
                element[1, 0] = 1;
            }
            else if (element[0, 1] == 0 && b[x -1, y + 1] == 0)
            {
                element[1, 2] = 0;
                element[0, 1] = 1;
            }
            else if (element[1, 2] == 0&& b[x + 1, y + 1] == 0)
            {
                element[2, 1] = 0;
                element[1, 2] = 1;
            }
        }
    }
    //右L
    public class rightL : BaseShape
    {
        public rightL()
        {
            element[0, 2] = 1;
            element[1, 0] = 1;
            element[1, 1] = 1;
            element[1, 2] = 1;
        }

        public override void transform(int[,] b)
        {
            for (int i = 20; i > 0; i--)
            {
                for (int n = 16; n > 0; n--)
                {
                    if (b[i, n] == 1)
                    {
                        x = i;
                        y = n;

                    }
                }
            }
            if (element[0, 2] == 1&&b[x,y-1]==0 && b[x+2, y ] == 0 && b[x + 2, y-1] == 0)
            {
                element[0, 2] = 0;
                element[1, 0] = 0;
                element[1, 2] = 0;
                element[0, 1] = 1;
                element[2, 1] = 1;
                element[2, 2] = 1;

            }
            else if (element[2, 2] == 1&&b[x+1,y+1]==0 && b[x +1, y - 1] == 0 && b[x +2, y - 1] == 0)
            {
                element[0, 1] = 0;
                element[2, 2] = 0;
                element[2, 1] = 0;
                element[2, 0] = 1;
                element[1, 2] = 1;
                element[1, 0] = 1;
            }
            else if (element[2, 0] == 1&&b[x-1,y]==0 && b[x - 1, y+1] == 0 && b[x + 1, y+1] == 0)
            {
                element[1, 0] = 0;
                element[1, 2] = 0;
                element[2, 0] = 0;
                element[0, 0] = 1;
                element[0, 1] = 1;
                element[2, 1] = 1;
            }
            else if (element[0, 0] == 1 && b[x , y+2] == 0 && b[x - 1, y+2] == 0 && b[x - 1, y-1] == 0)
            {
                element[0, 1] = 0;
                element[0, 0] = 0;
                element[2, 1] = 0;
                element[1, 0] = 1;
                element[1, 2] = 1;
                element[0, 2] = 1;
            }
           
        }
    }
    //竖向Z
    public class VerticalZ : BaseShape
    {
        public VerticalZ()
        {
            element[0, 1] = 1;
            element[1, 0] = 1;
            element[1, 1] = 1;
            element[2, 0] = 1;
        }
        public override void transform(int[,] b)
        {
            for (int i = 20; i > 0; i--)
            {
                for (int n = 16; n > 0; n--)
                {
                    if (b[i, n] == 1)
                    {
                        x = i;
                        y = n;
                    }
                }
            }
            if (element[2,0]==1&&b[x,y-1]==0 && b[x+1, y +1] == 0 && b[x-1, y - 2] == 0 && b[x - 2, y - 2] == 0)
            {
                element[1, 0] = 0;
                element[2, 0] = 0;
                element[0, 0] = 1;
                element[1, 2] = 1;

            }
            else if (element[0,0]==1&& b[x-1, y ] == 0 && b[x -2, y ] == 0)
            {
                element[1, 0] = 1;
                element[2, 0] = 1;
                element[0, 0] = 0;
                element[1, 2] = 0;
            }
        } 
    }
    //横向Z
    public class horizontalZ : BaseShape
    {
        public horizontalZ()
        {
            element[0, 1] = 1;
            element[0, 2] = 1;
            element[1, 0] = 1;
            element[1, 1] = 1;
        }
        public override void transform(int[,] b)
        {
            for (int i = 20; i > 0; i--)
            {
                for (int n = 16; n > 0; n--)
                {
                    if (b[i, n] == 1)
                    {
                        x = i;
                        y = n;
                    }
                }
            }
            if (element[0,2]==1&&b[x+1,y+1]==0 && b[x + 2, y + 1] == 0)
            {
                element[0, 2] = 0;
                element[1, 0] = 0;
                element[1, 2] = 1;
                element[2, 2] = 1;
            }
            else if (element[2,2]==1 && b[x , y + 1] == 0 && b[x - 1, y - 1] == 0 && b[x + 1, y + 2] == 0 && b[x + 2, y + 2] == 0)
            {
                element[0, 2] = 1;
                element[1, 0] = 1;
                element[1, 2] = 0;
                element[2, 2] = 0;
            }
        } 
    }
    
    //形状工厂
    public class ShapeMgr
    {
       static BaseShape Mgr;
        
        public static BaseShape GetShape() 
        {
            Random random = new Random();
            Shape ran = (Shape)random.Next(1, 8);
            switch (ran)
            {
                case Shape.Square:
                    Mgr = new Square();
                    break;
                case Shape.Line:
                    Mgr = new Line();
                    break;
                case Shape.leftL:
                    Mgr = new leftL();
                    break;
                case Shape.T:
                    Mgr = new ShapeT();
                    break;
                case Shape.rightL:
                    Mgr = new rightL();
                    break;
                case Shape.VerticalZ:
                    Mgr = new VerticalZ();
                    break;
                case Shape.horizontalZ:
                    Mgr = new horizontalZ();
                    break;
                default:
                    break;
            }
            
            return Mgr;
        }
    
    
    class Element 
    {
      
    }
}}
