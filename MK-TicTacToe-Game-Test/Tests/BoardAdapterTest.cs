using System;
using MK_TicTacToe_Game.Service;
using MK_TicTacToe_Game.Adapters;
using Xunit;

namespace MK_TicTacToe_Game_Test.Tests {
    public class BoardAdapterTest {
        BoardArrayAdapter adapter;
        public BoardAdapterTest(){
            adapter = new BoardArrayAdapter();
        }
        [Fact]
        public void GetBoardMatrix_returnsTwoDArray(){
            var boardSize = 3;
            var arrayOfArray = new string[boardSize][];
            for(int i = 0; i<boardSize; i++){
                arrayOfArray[i] = new string[boardSize];
                for(int j = 0; j<boardSize; j++){
                    arrayOfArray[i][j] = $"({i}, {j})";
                }
            }
            var twoDArray = adapter.GetBoardMatrix(arrayOfArray);
            
            Assert.NotNull(twoDArray);

            for(int i = 0; i<boardSize; i++){
                for(int j = 0; j<boardSize; j++){
                    Assert.Equal(arrayOfArray[i][j], twoDArray[i,j]);
                }
            }
            
        }
        
    }
}
