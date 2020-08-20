using System;
using System.Collections.Generic;
using System.Text;

namespace Tetirs
{
    enum Shape
    {
        Square=1, 
        Line,
        leftL,
        T,
        rightL,
        VerticalZ ,
        horizontalZ
    }

    public class GameDate
    {
        public static int hWell1;
        public static int hWell2;
        public static int hWell3;
        public static int vWell1;
        public static int vWell2;
        public static int vWell3;
        public static int row{ get; set; }
        public static int columns;
        public  int boardHeight = 22;
        public static int boardWeight = 24;
    }
}
