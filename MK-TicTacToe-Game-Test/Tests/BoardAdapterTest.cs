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
            var arrayOfArray = new string[3][];
            for(int i = 0; i<3; i++){
                arrayOfArray[i] = new string[3];
                for(int j = 0; j<3; j++){
                    arrayOfArray[i][j] = $"({i}, {j})";
                }
            }
            var twoDArray = adapter.GetBoardMatrix(arrayOfArray);
            
            Assert.NotNull(twoDArray);

            for(int i = 0; i<3; i++){
                for(int j = 0; j<3; j++){
                    Assert.Equal(arrayOfArray[i][j], twoDArray[i,j]);
                }
            }
            
        }
        
    }
}
