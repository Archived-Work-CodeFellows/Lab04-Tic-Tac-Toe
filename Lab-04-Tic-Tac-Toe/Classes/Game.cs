using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Tic_Tac_Toe.Classes
{
    /// <summary>
    /// This Class holds the logic for overall Game Play
    /// </summary>
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public GameBoard ActiveBoard { get; set; }
        public string Win { get; set; }
        //This 2D array stores all win conditions 
        int[,] WinConditions { get; } = new int[,]
        {
            {1,2,3},
            {4,5,6},
            {7,8,9},

            {1,4,7},
            {2,5,8},
            {3,6,9},

            {1,5,9},
            {3,5,7}
        };

        public Game(Player playOne, Player playTwo, GameBoard board)
        {
            Player1 = playOne;
            Player2 = playTwo;
            ActiveBoard = board;
        }
        /// <summary>
        /// Method that checks which player is active and changes
        /// the reference accordingly
        /// </summary>
        /// <param name="turn">Takes an int that is 0 or 1</param>
        /// <returns></returns>
        public Player WhoseTurn(int turn)
        {
            if(turn == 1)
            {
                return Player2;
            }
            return Player1;
        }
        /// <summary>
        /// Inspired by lecture, Method checks to see if there is a winning
        /// combination on the board. It stores the values from the WinConditions
        /// 2D array and creates Coordinates. It then takes the value of those Coordinates
        /// and compares if the three values from the Board indecies matches any conditions
        /// </summary>
        /// <returns>True if there is a match and changes the Player name reference, false if no winner at the time of calculation</returns>
        public bool IsWinner()
        {
           for(int i = 0; i < WinConditions.GetLength(0); i++)
            {
                Coordinates iOne = Player.CoordinateNumber(WinConditions[i, 0]);
                Coordinates iTwo = Player.CoordinateNumber(WinConditions[i, 1]);
                Coordinates iThree = Player.CoordinateNumber(WinConditions[i, 2]);

                string one = ActiveBoard.Board[iOne.Row, iOne.Column];
                string two = ActiveBoard.Board[iTwo.Row, iTwo.Column];
                string three = ActiveBoard.Board[iThree.Row, iThree.Column];

                if(one == two && two == three)
                {
                    Win = (one == "X" ? Player1.Name : Player2.Name);
                    return true;
                }
            }
            return false;
        }
    }
}
