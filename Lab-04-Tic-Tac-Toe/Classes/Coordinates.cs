using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Tic_Tac_Toe.Classes
{
    /// <summary>
    /// Inspired by what was shown in lecture, this class
    /// is to track specific coordinates in the
    /// tic-tac-toe array for Win Condition comparisons
    /// </summary>
    public class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
