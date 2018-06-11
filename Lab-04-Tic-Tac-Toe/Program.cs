using System;
using Lab_04_Tic_Tac_Toe.Classes;

namespace Lab_04_Tic_Tac_Toe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");         
        }

        static void GamePlay()
        {
            GameBoard board = new GameBoard();
            board.BoardDisplay(" ", " ");
            
        }
    }
}
