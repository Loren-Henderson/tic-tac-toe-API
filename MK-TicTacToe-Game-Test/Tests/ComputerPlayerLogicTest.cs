using System;
using Xunit;
using MK_TicTacToe_Game.Service;

namespace MK_TicTacToe_Game_Test.Tests {
    public class ComputerPlayerLogicTest {
        ComputerPlayerLogic computerPlayerLogic;
        string[,] board;
        public ComputerPlayerLogicTest(){
            computerPlayerLogic = new ComputerPlayerLogic();
            board = new string[3,3]{{"","",""},{"","",""},{"","",""}};
        }
        
        // _ _ _
        // _ _ _
        // _ _ _
        [Fact]
        public void GetBestPoint_returnsBestPoint_whenBoardEmpty() {
            var board = new string[3,3];
            var bestPoint = computerPlayerLogic.GetBestPoint(board);

            Assert.Equal(1, bestPoint.X);
            Assert.Equal(1, bestPoint.Y);
        }
        // _ _ _
        // _ X _
        // _ _ _
        [Fact]
        public void GetBestPoint_returnsBestPoint_whenBoardHasPoints(){
            board[1, 1] = "X";
            var bestPoint = computerPlayerLogic.GetBestPoint(board);

            Assert.Equal(0, bestPoint.X);
            Assert.Equal(0, bestPoint.Y);
        }
        
        // O X O
        // O X X
        // X O O
        [Fact]
        public void GetBestPoint_returnsBestPoint_whenBoardIsFull(){
            for(var i = 0; i < board.GetLength(0); i++){
                for(var j = 0; j < board.GetLength(1); j++){
                    board[i,j] = "X";
                }
            }
            var bestPoint = computerPlayerLogic.GetBestPoint(board);
            Assert.Null(bestPoint);
        }
        
    }
}
