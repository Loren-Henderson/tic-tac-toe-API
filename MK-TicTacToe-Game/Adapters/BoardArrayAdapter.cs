namespace MK_TicTacToe_Game.Adapters{
 public class BoardArrayAdapter: IBoardArrayAdapter{
     public string[,] GetBoardMatrix(string[][] board){
        var result = new string[board.Length, board.Length];
        for(var i = 0; i < board.Length; i++){
            for(var j = 0; j < board[i].Length; j++){
                result[i,j] = board[i][j];
            }
        }
        return result;
     }
 }
}