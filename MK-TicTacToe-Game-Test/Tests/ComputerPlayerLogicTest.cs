using System;
using Xunit;
using MK_TicTacToe_Game.Service;

namespace MK_TicTacToe_Game_Test.Tests {
    public class ComputerPlayerLogicTest {
        ComputerPlayerLogic computerPlayerLogic;
        string[][] board;
        public ComputerPlayerLogicTest(){
            computerPlayerLogic = new ComputerPlayerLogic();
            board = new []{new []{"","",""},new []{"","",""},new []{"","",""}};
        }
        
        // _ _ _
        // _ _ _
        // _ _ _
        [Fact]
        public void GetBestPoint_returnsBestPoint_whenBoardEmpty() {
            var board = new []{new []{"","",""},new []{"","",""},new []{"","",""}};
            var bestPoint = computerPlayerLogic.GetBestPoint(board);

            Assert.Equal(1, bestPoint.X);
            Assert.Equal(1, bestPoint.Y);
        }
        // _ _ _
        // _ X _
        // _ _ _
        [Fact]
        public void GetBestPoint_returnsBestPoint_whenBoardHasPoints(){
            board[1][1] = "X";
            var bestPoint = computerPlayerLogic.GetBestPoint(board);

            Assert.Equal(0, bestPoint.X);
            Assert.Equal(0, bestPoint.Y);
        }
        
        // O X O
        // O X X
        // X O O
        [Fact]
        public void GetBestPoint_returnsNull_WhenBoardIsFull(){
            for(var i = 0; i < board.Length; i++){
                for(var j = 0; j < board[i].Length; j++){
                    board[i][j] = "X";
                }
            }
            var bestPoint = computerPlayerLogic.GetBestPoint(board);
            Assert.Null(bestPoint);
        }

        [Fact]
        public void GetBestPoint_BlocksPlayer_ifPlayerHasTwoInARow()
        {
            board[0][0] = "X";
            board[0][1] = "X";
            board[1][1] = "O";
          

            var bestPoint = computerPlayerLogic.GetBestPoint(board);

            Assert.Equal(0, bestPoint.X);
            Assert.Equal(2, bestPoint.Y);
        }
        
    }
}
