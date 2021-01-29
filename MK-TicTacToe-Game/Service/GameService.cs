using MK_TicTacToe_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MK_TicTacToe_Game.Service {
    public class GameService : IGameService {
        ComputerPlayerLogic _computerPlayerLogic;
        public GameService(ComputerPlayerLogic computerPlayerLogic){
            _computerPlayerLogic = computerPlayerLogic;
        }

        public async Task<GameState> GetComputerNextMove(string[][] board){
            var result = new GameState(getCorrectBoard(board));
            // var nextMovePoint = getCompMove(board);
            // result.Board[nextMovePoint.X,nextMovePoint.Y] = "O";
            // result.Status = GameStatus.Undefined;
            return result;
        }

        string[,] getCorrectBoard(string[][] board){
            var result = new string[board.Length, board.Length];
            return result;
        }




    }
}
