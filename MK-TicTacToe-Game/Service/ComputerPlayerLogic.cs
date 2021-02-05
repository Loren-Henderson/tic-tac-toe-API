using System;
using MK_TicTacToe_Game.Models;

namespace MK_TicTacToe_Game.Service {
    public class ComputerPlayerLogic: IComputerPlayerLogic{

        public Point GetBestPoint(string[][] boardMatrix) {
            if(string.IsNullOrEmpty(boardMatrix[1][1])){
                return new Point(1, 1);
            }
            for(var i = 0; i < boardMatrix.Length; i++){
                for(var j = 0; j < boardMatrix[i].Length; j++){
                   if(string.IsNullOrEmpty(boardMatrix[i][j])){
                        return new Point(i, j);
                    }
                }
            }
            return null;
        }




    }
}