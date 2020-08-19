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
       public static int[,] checkerboard = new int[22, 24];
    }
}
