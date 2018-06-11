using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Tic_Tac_Toe.Classes
{
    public class GameBoard
    {
        public string[,] Board { get; set; }

        public GameBoard()
        {
            Board = new[,] {
                { "1","2","3" },
                { "4","5","6" },
                { "7","8","9" }
            };
        }

        public void BoardDisplay(string position, string marker)
        {
            Console.Clear();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == position) Board[i, j] = marker;
                    Console.Write($"|{Board[i, j]}|");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
