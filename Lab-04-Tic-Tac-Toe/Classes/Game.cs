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

        public Game()
        {

        }

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
        /// <summary>
        /// Method holds the GamePlay interaction visual logic. Helps
        /// set up all instances that will be used for the current round
        /// </summary>
        public void GamePlay()
        {
            Console.Clear();
            GameBoard board = new GameBoard();

            Console.WriteLine("Alright, player X, what is your name?");
            string num1 = Console.ReadLine();
            Player player1 = new Player(num1, "X");

            Console.Clear();

            Console.WriteLine("Player O, it is your turn.");
            string num2 = Console.ReadLine();
            Player player2 = new Player(num2, "O");

            Game gameInstance = new Game(player1, player2, board);
            board.BoardDisplay(" ", " ");

            ActiveGame(gameInstance);

            Console.Clear();
            if (gameInstance.IsWinner()) Console.WriteLine($"Yay you did it {gameInstance.Win}!");
            else Console.WriteLine("Darn, no winners this time!");

        }
        /// <summary>
        /// Method for Game interaction. Keeps track of turns and whose turn
        /// it is currently.
        /// </summary>
        /// <param name="gameInstance">Takes a Game object to affect all current references</param>
        static void ActiveGame(Game gameInstance)
        {
            int playerTurn = 0;
            int totalTurns = 0;
            Player current = gameInstance.WhoseTurn(playerTurn);

            while (totalTurns < 9)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"{gameInstance.Player1.Name} marker: {gameInstance.Player1.Marker}");
                Console.WriteLine($"{gameInstance.Player2.Name} marker: {gameInstance.Player2.Marker}");
                Console.WriteLine(" ");
                Console.WriteLine($"It's your turn {current.Name}");
                Console.WriteLine("Pick a spot!");

                string position = Console.ReadLine();
                //To check if the user input is actually a number
                try
                {
                    short positionChecker = Int16.Parse(position);
                    bool taken = gameInstance.ActiveBoard.PositionChecker(position, totalTurns);
                    //This is to remove negative possibilities and only accept 1-9 as input
                    if (taken && positionChecker * -1 < 10 && positionChecker > 0)
                    {
                        gameInstance.ActiveBoard.BoardDisplay(position, current.Marker);

                        bool check = gameInstance.IsWinner();
                        totalTurns = check ? 9 : totalTurns;

                        playerTurn = playerTurn > 0 ? 0 : 1;
                        totalTurns++;
                        current = gameInstance.WhoseTurn(playerTurn);
                    }
                    else
                    {
                        Console.WriteLine($"Try again {current.Name}!");
                        Console.ReadLine();
                    }
                }
                catch (FormatException) //Catches blank input
                {
                    Console.WriteLine($"Nice try {current.Name}. I only except the numbers on the screen!");
                    Console.ReadLine();
                }
                catch (OverflowException) //Catches number inputs too large for type short
                {
                    Console.WriteLine($"{current.Name}...are you even trying to play?");
                    Console.ReadLine();
                }
                gameInstance.ActiveBoard.BoardDisplay(" ", " ");
            }
        }
    }
}
