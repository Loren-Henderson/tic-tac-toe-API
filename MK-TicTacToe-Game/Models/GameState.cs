
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
            result.UpdateStatus();
            return result;
        }

        private void UpdateStatus() {
            bool IsCat = true;

            for (int i = 0; i < 3; i++) {
                // Detecting Horizontal Wins
                if (!string.IsNullOrEmpty(Board[i, 0])) {
                    if (Board[i, 1] == Board[i, 2] && Board[i, 0] == Board[i, 2])
                    {
                        WinLine_StartBox = ConvertArrayToBoxValue(i, 0);
                        WinLine_EndBox = ConvertArrayToBoxValue(i, 2);
                        Status = Board[i, 0] == "X" ? GameStatus.X : GameStatus.O;
                        return;
                    }
                }

                // Detecting Verticle Wins
                if (!string.IsNullOrEmpty(Board[0, i]))
                {
                    if (Board[1, i] == Board[2, i] && Board[0, i] == Board[2, i])
                    {
                        WinLine_StartBox = ConvertArrayToBoxValue(0, i);
                        WinLine_EndBox = ConvertArrayToBoxValue(2, i);
                        Status = Board[0, i] == "X" ? GameStatus.X : GameStatus.O;
                        return;
                    }
                }

                if (
                    string.IsNullOrEmpty(Board[i, 0]) ||
                    string.IsNullOrEmpty(Board[i, 1]) ||
                    string.IsNullOrEmpty(Board[i, 2])
                    ) {
                    IsCat = false;
                }

            }

            // Detecting Diagonal Wins
            if (!string.IsNullOrEmpty(Board[1, 1]))
            {
                // Top Left to Bottom Right
                if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2]) {
                    WinLine_StartBox = ConvertArrayToBoxValue(0, 0);
                    WinLine_EndBox = ConvertArrayToBoxValue(2, 2);
                    Status = Board[1, 1] == "X" ? GameStatus.X : GameStatus.O;
                    return;
                }

                // Top Right to Bottom Left
                if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
                {
                    WinLine_StartBox = ConvertArrayToBoxValue(0, 2);
                    WinLine_EndBox = ConvertArrayToBoxValue(2, 0);
                    Status = Board[1, 1] == "X" ? GameStatus.X : GameStatus.O;
                    return;
                }
            }

            if (IsCat)
            {
                Status = GameStatus.Cats;
            }
            else {
                Status = GameStatus.Undefined;
            }

        }

        private int ConvertArrayToBoxValue(int i, int j) {
            return i * 3 + j + 1;
        }
    }
}
