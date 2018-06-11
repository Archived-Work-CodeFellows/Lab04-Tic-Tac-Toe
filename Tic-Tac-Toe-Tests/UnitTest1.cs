using System;
using Xunit;
using Lab_04_Tic_Tac_Toe;
using Lab_04_Tic_Tac_Toe.Classes;

namespace Tic_Tac_Toe_Tests
{
    public class UnitTest1
    {
        //Test Player Turn switches
        [Fact]
        public void PlayerXTurn()
        {
            GameBoard gameBoard = new GameBoard();
            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);

            Assert.Equal(playX, gameInstance.WhoseTurn(0));
        }
        [Fact]
        public void PlayerOTurn()
        {
            GameBoard gameBoard = new GameBoard();
            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);

            Assert.Equal(playY, gameInstance.WhoseTurn(1));
        }
        //Testing for win conditions
        [Fact]
        public void WinConditions()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.Board  = new string[ , ] { { "X", "X", "O" }, { "X", "O", "O" }, { "X", "O", "X" } };

            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);

            Assert.True(gameInstance.IsWinner());
        }
        [Fact]
        public void WinConditions2()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.Board = new string[,] { { "O", "X", "X" }, { "X", "O", "X" }, { "X", "O", "O" } };

            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);

            Assert.True(gameInstance.IsWinner());
        }
        [Fact]
        public void WinConditionDraw()
        {
            GameBoard gameBoard = new GameBoard();
            gameBoard.Board = new string[,] { { "O", "X", "X" }, { "X", "O", "O" }, { "X", "O", "X" } };

            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);

            Assert.False(gameInstance.IsWinner());
        }

    }
}
