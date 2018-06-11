using System;
using Lab_04_Tic_Tac_Toe.Classes;

namespace Lab_04_Tic_Tac_Toe
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppMenu();
        }
        /// <summary>
        /// Method holds all the Menu interaction logic and calls appropriate
        /// methods based on user input
        /// </summary>
        static void AppMenu()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe, Three in a row!");
            Console.Write("\n\n");
            Console.WriteLine("Start a new game? yes/no");
            string input = Console.ReadLine().ToLower();

            if (input == "yes" || input == "y")
            {
                bool replay = false;
                do
                {
                    GamePlay();

                    Console.WriteLine("Play again? yes/no");
                    string playAgain = Console.ReadLine().ToLower();

                    if (playAgain == "yes" || playAgain == "y") replay = true;
                    else replay = false;

                } while (replay);
            }
            Console.Clear();
            Console.WriteLine("Okay maybe next time! bye!");
        }
        /// <summary>
        /// Method holds the GamePlay interaction visual logic. Helps
        /// set up all instances that will be used for the current round
        /// </summary>
        static void GamePlay()
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
