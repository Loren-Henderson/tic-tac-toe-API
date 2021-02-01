using System;
using MK_TicTacToe_Game.Service;
using MK_TicTacToe_Game.Models;
using MK_TicTacToe_Game.Adapters;
using Xunit;
using System.Threading.Tasks;
using Moq;

namespace MK_TicTacToe_Game_Test.Tests {
    public class GameServiceTest {
        
        Mock<IComputerPlayerLogic> mockCompPlayerLogic;
        Mock<IBoardArrayAdapter> mockArrayAdapter;
        public GameServiceTest(){
            mockCompPlayerLogic = new Mock<IComputerPlayerLogic>();
            mockArrayAdapter = new Mock<IBoardArrayAdapter>();
        }

        [Fact]
        public async Task GetComputerNextMove_returnsNextState(){
            var arrayOfArray = new string[3][];
            var twoDArray = new string[3, 3];
            mockArrayAdapter.Setup(aa => aa.GetBoardMatrix(arrayOfArray)).Returns(twoDArray);
            mockCompPlayerLogic.Setup(cl => cl.GetBestPoint(twoDArray)).Returns(new Point(1,1));

            var service = new GameService(mockCompPlayerLogic.Object, mockArrayAdapter.Object);

            var result = await service.GetComputerNextMove(arrayOfArray);

            Assert.Equal(GameStatus.Undefined, result.Status);
            Assert.Equal("O", result.Board[1,1]);

        }
    }
}
