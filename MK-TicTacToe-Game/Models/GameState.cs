
namespace MK_TicTacToe_Game.Models {
    public class GameState {
        public GameState(string[,] board){
            Board = board;
        }
        public string[,] Board { get; private set; } = new string[3, 3];
        public int WinLine_StartBox { get; set; }
        public int WinLine_EndBox { get; set; }
        public GameStatus Status { get; set; }
        
    }
}
