using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Tic_Tac_Toe.Classes
{
    /// <summary>
    /// This Class is to create a Player based on a given name and given marker
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public string Marker { get; set; }
        public int Row { get; }
        public int Column { get; }

        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }
        /// <summary>
        /// Inspired by lecture, This method is used inconjunction with the
        /// Game Class Win Conditions and supplies row and column values
        /// for the 2D array
        /// </summary>
        /// <param name="position">Takes the value stored in WinConditions 2d array</param>
        /// <returns>Coordinates Object with appropriate 2D array position values</returns>
        public static Coordinates CoordinateNumber(int position)
        {
            switch (position)
            {
                case 1: return new Coordinates(0, 0);
                case 2: return new Coordinates(0, 1);
                case 3: return new Coordinates(0, 2);
                case 4: return new Coordinates(1, 0);
                case 5: return new Coordinates(1, 1);
                case 6: return new Coordinates(1, 2);
                case 7: return new Coordinates(2, 0);
                case 8: return new Coordinates(2, 1);
                case 9: return new Coordinates(2, 2);
                default: return null;
            }
        }
    }
}
