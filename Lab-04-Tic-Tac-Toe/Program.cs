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
            Game start = new Game();
            if (input == "yes" || input == "y")
            {
                bool replay = false;
                do
                {
                    start.GamePlay();

                    Console.WriteLine("Play again? yes/no");
                    string playAgain = Console.ReadLine().ToLower();

                    if (playAgain == "yes" || playAgain == "y") replay = true;
                    else replay = false;

                } while (replay);
            }
            Console.Clear();
            Console.WriteLine("Okay maybe next time! bye!");
        }
    }
}
