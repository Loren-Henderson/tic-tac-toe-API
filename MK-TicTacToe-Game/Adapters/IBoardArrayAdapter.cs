namespace MK_TicTacToe_Game.Adapters{
    public interface IBoardArrayAdapter
    {
        string[,] GetBoardMatrix(string[][] board);
    }
}