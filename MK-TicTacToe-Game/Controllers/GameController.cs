using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MK_TicTacToe_Game.Service;
using MK_TicTacToe_Game.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MK_TicTacToe_Game.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase {
        private IGameService _gameService;
        public GameController(IGameService gameService){
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<GameState> GetNextState(string[][] board){
            return await _gameService.GetComputerNextMove(board);
        }
        
    }
}
