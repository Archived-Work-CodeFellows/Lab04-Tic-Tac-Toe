using System;
using Lab_04_Tic_Tac_Toe.Classes;

namespace Lab_04_Tic_Tac_Toe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AppMenu();
        }

        static void AppMenu()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe, Three in a row!");
            Console.Write("\n\n");
            Console.WriteLine("Start a new game? yes/no");
            string input = Console.ReadLine().ToLower();

            if (input == "yes" || input == "y")
            {
                bool replay = true;
                while (replay)
                {
                    replay = GamePlay();
                }
            }
            Console.Clear();
            Console.WriteLine("Okay maybe next time! bye!");
        }

        static bool GamePlay()
        {
            Console.Clear();
            GameBoard board = new GameBoard();

            Console.WriteLine("Alright, player X, what is your name?");
            string num1 = Console.ReadLine();
            Player player1 = new Player(num1, "X");

            Console.Clear();

            Console.WriteLine("Player O, it is your turn.?");
            string num2 = Console.ReadLine();
            Player player2 = new Player(num2, "O");

            Console.Write($"{player1.Name} {player1.Name}");
            Console.WriteLine(" ");

            Game gameInstance = new Game(player1, player2, board);
            board.BoardDisplay(" ", " ");

            ActiveGame(gameInstance);

            Console.Clear();
            Console.WriteLine($"Yay you did it {gameInstance.Win}!");
            Console.WriteLine("You tic-tac-toe-ed! Play again? yes/no");
            string input = Console.ReadLine().ToLower();
            if (input == "yes" || input == "y") return true;
            return false;
        }

        static void ActiveGame(Game gameInstance)
        {
            int playerTurn = 0;
            int totalTurns = 0;
            while (totalTurns < 9)
            {
                Console.WriteLine($"{gameInstance.Player1.Name} marker: {gameInstance.Player1.Marker}");
                Console.WriteLine($"{gameInstance.Player2.Name} marker: {gameInstance.Player2.Marker}");
                Player current = gameInstance.WhoseTurn(playerTurn);
                Console.WriteLine(" ");
                Console.WriteLine($"It's your turn {current.Name}");
                Console.WriteLine("Pick a spot!");

                string position = Console.ReadLine();
                gameInstance.ActiveBoard.BoardDisplay(position, current.Marker);

                bool check = gameInstance.IsWinner();
                totalTurns = check ? 9 : totalTurns;

                playerTurn = playerTurn > 0 ? 0 : 1;
                totalTurns++;
            }
        }
    }
}
