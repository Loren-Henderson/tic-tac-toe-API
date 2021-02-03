using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MK_TicTacToe_Game.Service;
using MK_TicTacToe_Game.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace MK_TicTacToe_Game.Controllers {
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class GameController : ControllerBase {
        private IGameService _gameService;
        public GameController(IGameService gameService){
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> GetNextState(string[][] board){
            return Ok(await _gameService.GetComputerNextMove(board));
        }
        
    }
}
