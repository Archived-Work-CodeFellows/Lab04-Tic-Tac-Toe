using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_Tic_Tac_Toe.Classes
{
    class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Game(Player playOne, Player playTwo)
        {
            playOne = Player1;
            playTwo = Player2;
        }



    }
}
