
namespace MK_TicTacToe_Game.Models {
    public class GameState {

        private GameState(){}
        
        public string[,] Board { get; private set; } = new string[3, 3];
        public int WinLine_StartBox { get; set; }
        public int WinLine_EndBox { get; set; }
        public GameStatus Status { get; private set; }

        public static GameState GetGameState(string[,] board){
            var result = new GameState();
            result.Board = board;
            result.Status = GameStatus.Undefined;
            return result;
        }
    }
}
