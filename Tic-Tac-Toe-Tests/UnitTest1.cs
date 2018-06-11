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
            GameBoard gameBoard = new GameBoard
            {
                Board = new string[,] { { "X", "X", "O" }, { "X", "O", "O" }, { "X", "O", "X" } }
            };

            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);

            Assert.True(gameInstance.IsWinner());
        }
        [Fact]
        public void WinConditions2()
        {
            GameBoard gameBoard = new GameBoard
            {
                Board = new string[,] { { "O", "X", "X" }, { "X", "O", "X" }, { "X", "O", "O" } }
            };

            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);

            Assert.True(gameInstance.IsWinner());
        }
        [Fact]
        public void WinConditionDraw()
        {
            GameBoard gameBoard = new GameBoard
            {
                Board = new string[,] { { "O", "X", "X" }, { "X", "O", "O" }, { "X", "O", "X" } }
            };

            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);

            Assert.False(gameInstance.IsWinner());
        }
        //Test to check available positions in a current game state
        [Theory]
        [InlineData("4", 6)]
        [InlineData("6", 6)]
        [InlineData("3", 6)]
        public void TakenPositions(string position, int nextTurn)
        {
            GameBoard gameBoard = new GameBoard
            {
                TakenPositions = new string[] { "1", "4", "2", "6", "8", "3", "0", "0", "0" }
            };
            Assert.False(gameBoard.PositionChecker(position, nextTurn));
        }
        [Theory]
        [InlineData("5", 6)]
        [InlineData("7", 6)]
        [InlineData("9", 6)]
        public void TakePosition(string position, int nextTurn)
        {
            GameBoard gameBoard = new GameBoard
            {
                TakenPositions = new string[] { "1", "4", "2", "6", "8", "3", "0", "0", "0" }
            };
            Assert.True(gameBoard.PositionChecker(position, nextTurn));
        }
        //Check Winner Name
        [Fact]
        public void WinnerName()
        {
            GameBoard gameBoard = new GameBoard
            {
                Board = new string[,] { { "X", "X", "O" }, { "X", "O", "O" }, { "X", "O", "X" } }
            };

            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);
            gameInstance.IsWinner();

            Assert.Equal("playX",gameInstance.Win);
        }
        [Fact]
        public void WinnerName2()
        {
            GameBoard gameBoard = new GameBoard
            {
                Board = new string[,] { { "X", "X", "O" }, { "O", "O", "O" }, { "X", "O", "X" } }
            };

            Player playX = new Player("playX", "X");
            Player playY = new Player("playY", "O");
            Game gameInstance = new Game(playX, playY, gameBoard);
            gameInstance.IsWinner();

            Assert.Equal("playY", gameInstance.Win);
        }
    }
}
