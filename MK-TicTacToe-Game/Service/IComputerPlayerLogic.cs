using MK_TicTacToe_Game.Models;

public interface IComputerPlayerLogic{
    Point GetBestPoint(string[,] boardMatrix);
}