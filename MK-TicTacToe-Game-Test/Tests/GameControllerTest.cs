using MK_TicTacToe_Game.Service;
using MK_TicTacToe_Game.Models;
using Xunit;
using System.Threading.Tasks;
using Moq;
using MK_TicTacToe_Game.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MK_TicTacToe_Game_Test.Tests
{
    public class GameControllerTest
    {
        Mock<IGameService> mockGameService;

        public GameControllerTest()
        {
            mockGameService = new Mock<IGameService>();
        }

        [Fact]
        public async Task GetNextState_ReturnsNotNull()
        {
            var arrayOfArray = new string[3][];

            mockGameService.Setup(aa => aa.GetComputerNextMove(arrayOfArray)).ReturnsAsync(GameState.GetGameState(new string[3,3]));
            var controller = new GameController(mockGameService.Object);

            var result = await controller.GetNextState(arrayOfArray);
            var objresult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(200, objresult.StatusCode);
            mockGameService.Verify();

        }
    }
}
