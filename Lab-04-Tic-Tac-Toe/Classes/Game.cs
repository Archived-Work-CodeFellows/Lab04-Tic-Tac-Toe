using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Tic_Tac_Toe.Classes
{
    class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        readonly int[,] WinConditions = new int[,]
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

        public Game(Player playOne, Player playTwo)
        {
            Player1 = playOne;
            Player2 = playTwo;
        }

        public bool IsWinner(GameBoard board, Player currentPlayer)
        {
            //for(int i = 0; i < board.Board.GetLength(0); i++)
            //{
            //    for(int j = 0; j < board.Board.GetLength(1); j++)
            //    {
            //        if( WinConditions[i,j] == i+1 && board.Board[i,j] == currentPlayer.Marker)

            //    }
            //}

            return false;
        }

        public Player WhoseTurn(int turn)
        {
            if(turn == 1)
            {
                return Player2;
            }
            return Player1;
        }
    }
}
