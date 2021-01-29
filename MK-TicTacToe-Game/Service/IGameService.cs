using MK_TicTacToe_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MK_TicTacToe_Game.Service {
    public interface IGameService {

        Task<GameState> GetComputerNextMove(string[][] board);
    }
}