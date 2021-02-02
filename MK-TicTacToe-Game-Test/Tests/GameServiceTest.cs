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

        [Fact]
        public async Task GetComputerNextMove_ReturnsCatsGame_WhenGameIsOverWithoutWinner() {
            var boardSize = 3;
            var twoDArray = new string[3, 3];
            var arrayOfArray = new string[boardSize][];
            for (int i = 0; i < boardSize; i++)
            {
                arrayOfArray[i] = new string[boardSize];
            }
            twoDArray[0,0] = "X";
            twoDArray[0,1] = "O";
            twoDArray[0,2] = "X";
            twoDArray[1,0] = "O";
            twoDArray[1,1] = "X";
            twoDArray[1,2] = "O";
            twoDArray[2,0] = "O";
            twoDArray[2,1] = "X";

            // x o x
            // o x o
            // o x 

            mockArrayAdapter.Setup(aa => aa.GetBoardMatrix(arrayOfArray)).Returns(twoDArray);
            mockCompPlayerLogic.Setup(cl => cl.GetBestPoint(twoDArray)).Returns(new Point(2, 2));

            var service = new GameService(mockCompPlayerLogic.Object, mockArrayAdapter.Object);

            var result = await service.GetComputerNextMove(arrayOfArray);

            Assert.Equal(GameStatus.Cats, result.Status);
        }

        [Fact]
        public async Task GetComputerNextMove_ReturnsOWins_WhenComputerWinsGame()
        {
            var boardSize = 3;
            var twoDArray = new string[3, 3];
            var arrayOfArray = new string[boardSize][];
            for (int i = 0; i < boardSize; i++)
            {
                arrayOfArray[i] = new string[boardSize];
            }
            twoDArray[0, 0] = "O";
            twoDArray[0, 1] = "X";
            twoDArray[0, 2] = "O";
            twoDArray[1, 0] = "X";
            twoDArray[1, 1] = "O";
            twoDArray[1, 2] = "X";
            twoDArray[2, 0] = "X";
            twoDArray[2, 1] = "O";

            // o x o
            // x o x
            // x o

            mockArrayAdapter.Setup(aa => aa.GetBoardMatrix(arrayOfArray)).Returns(twoDArray);
            mockCompPlayerLogic.Setup(cl => cl.GetBestPoint(twoDArray)).Returns(new Point(2, 2));

            var service = new GameService(mockCompPlayerLogic.Object, mockArrayAdapter.Object);

            var result = await service.GetComputerNextMove(arrayOfArray);

            Assert.Equal(GameStatus.O, result.Status);
        }

        [Fact]
        public async Task GetComputerNextMove_ReturnsPlayerWins_WhenXMakes3InARow()
        {
            var boardSize = 3;
            var twoDArray = new string[3, 3];
            var arrayOfArray = new string[boardSize][];
            for (int i = 0; i < boardSize; i++)
            {
                arrayOfArray[i] = new string[boardSize];
            }
            twoDArray[0, 0] = "X";
            twoDArray[0, 1] = "O";
            twoDArray[0, 2] = "X";
            twoDArray[1, 0] = "O";
            twoDArray[1, 1] = "X";
            twoDArray[1, 2] = "O";
            twoDArray[2, 0] = "O";
            twoDArray[2, 2] = "X";

            // x o x
            // o x o
            // o   x

            mockArrayAdapter.Setup(aa => aa.GetBoardMatrix(arrayOfArray)).Returns(twoDArray);
            mockCompPlayerLogic.Setup(cl => cl.GetBestPoint(twoDArray)).Returns(new Point(2, 1));

            var service = new GameService(mockCompPlayerLogic.Object, mockArrayAdapter.Object);

            var result = await service.GetComputerNextMove(arrayOfArray);

            Assert.Equal(GameStatus.X, result.Status);
            Assert.Null(result.Board[2, 1]);
        }
    }
}
