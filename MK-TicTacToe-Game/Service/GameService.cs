using MK_TicTacToe_Game.Models;
using MK_TicTacToe_Game.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MK_TicTacToe_Game.Service {
    public class GameService : IGameService {
        IComputerPlayerLogic _computerPlayerLogic;
        IBoardArrayAdapter _arrayAdapter;
        public GameService(IComputerPlayerLogic computerPlayerLogic, IBoardArrayAdapter arrayAdapter){
            _computerPlayerLogic = computerPlayerLogic;
            _arrayAdapter= arrayAdapter;
        }

        public async Task<GameState> GetComputerNextMove(string[][] board){
            //var twoDArray = _arrayAdapter.GetBoardMatrix(board);
           
            var result = GameState.GetGameState(board);

            if (result.Status == GameStatus.Undefined) {
                var bestPoint = _computerPlayerLogic.GetBestPoint(board);
                board[bestPoint.X][bestPoint.Y] = "O";
                result = GameState.GetGameState(board);
            }

            return result;
        }

    }
}
