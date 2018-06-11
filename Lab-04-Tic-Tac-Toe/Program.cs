using System;
using Lab_04_Tic_Tac_Toe.Classes;

namespace Lab_04_Tic_Tac_Toe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe, Three in a row!");
            Console.Write("\n\n");
            Console.WriteLine("Start a new game? yes/no");
            string input = Console.ReadLine().ToLower();

            if (input == "yes" || input == "y")
            {
                GamePlay();
            }
            Console.Clear();
            Console.WriteLine("Okay maybe next time! bye!");
        }

        static void GamePlay()
        {
            Console.Clear();
            GameBoard board = new GameBoard();

            Console.WriteLine("Alright, player X, what is your name?");
            string num1 = Console.ReadLine();
            Player player1 = new Player(num1, "X");

            Console.WriteLine("Player O, it is your turn.?");
            string num2 = Console.ReadLine();
            Player player2 = new Player(num2, "O");

            Console.Write($"{player1.Name} {player1.Name}");
            Console.WriteLine(" ");

            Game gameInstance = new Game(player1, player2);
            board.BoardDisplay(" ", " ");

            int turn = 0;
            while (true)
            {
                Player current = gameInstance.WhoseTurn(turn);
                Console.WriteLine(" ");
                Console.WriteLine($"It's your turn {current.Name}");
                Console.WriteLine("Pick a spot!");

                string position = Console.ReadLine();
                board.BoardDisplay(position, current.Marker);

                turn = turn  > 0 ? 0 : 1;
            }
        }
    }
}
