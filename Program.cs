using System;

namespace Tetirs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;//光标不可见
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            GameProgram gameProgram = new GameProgram();
            
            gameProgram.StartGame();
            
            
        }
    }
}
