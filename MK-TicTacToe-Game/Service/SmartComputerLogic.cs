using MK_TicTacToe_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MK_TicTacToe_Game.Service {
    public class SmartComputerLogic : IComputerPlayerLogic {

        private double[,] _boardPoints;
        private string opoPlayerSign = "X";
        private string _playerSign = "O";
        public Point GetBestPoint(string[][] boardMatrix) {
            var result = new List<Point>();
            rebuildBoardPoints(boardMatrix);
            double maxPoints = 0;
            for (int x = 0; x < boardMatrix.Length; x++) {
                for (int y = 0; y < boardMatrix[x].Length; y++) {
                    if (_boardPoints[x, y] > maxPoints) {
                        maxPoints = _boardPoints[x, y];
                        var point = new Point(x, y);
                        if (maxPoints > 10) {
                            return point;
                        }
                        result = new List<Point>() { point };
                    } else if (_boardPoints[x, y] == maxPoints) {
                        result.Add(new Point(x, y));
                    }
                }
            }

            return result[new Random().Next(result.Count - 1)];
        }
        private void rebuildBoardPoints(string[][] boardMatrix) {
            _boardPoints = new double[boardMatrix.Length, boardMatrix.Length];
            var winPoints = new Dictionary<string, List<(int x, int y, bool isFreePoint)>>();

            var checkAndAdd = new Action<string, int, int, string>((key, x, y, sign) => {
                if (string.IsNullOrEmpty(boardMatrix[x][y]) || boardMatrix[x][y] == sign) {
                    if (winPoints.ContainsKey(key)) {
                        winPoints[key].Add((x, y, string.IsNullOrEmpty(boardMatrix[x][y])));
                    }
                } else {
                    winPoints.Remove(key);
                }
            });

            #region 
            winPoints.Add("D1", new List<(int x, int y, bool isFreePoint)>());
            winPoints.Add("D2", new List<(int x, int y, bool isFreePoint)>());
            for (int i = 0; i < boardMatrix.Length; i++) {
                checkAndAdd("D1", i, i, _playerSign);
                checkAndAdd("D2", i, boardMatrix.Length - 1 - i, _playerSign);

                winPoints.Add("I" + i, new List<(int x, int y, bool isFreePoint)>());
                winPoints.Add("J" + i, new List<(int x, int y, bool isFreePoint)>());

                for (int j = 0; j < boardMatrix.Length; j++) {
                    checkAndAdd("I" + i, i, j, _playerSign);
                    checkAndAdd("J" + i, j, i, _playerSign);
                }
            }
            foreach (var winPoint in winPoints) {
                var lastPoint = -1;
                var pointsToWin = 0;
                for (var i = 0; i < winPoint.Value.Count; i++) {
                    if (winPoint.Value[i].isFreePoint) {
                        pointsToWin++;
                        lastPoint = i;
                        _boardPoints[winPoint.Value[i].x, winPoint.Value[i].y]++;
                    }
                }
                if (pointsToWin == 1) {
                    _boardPoints[winPoint.Value[lastPoint].x, winPoint.Value[lastPoint].y] += 11;
                }
            }
            #endregion

            #region oposit
            winPoints = new Dictionary<string, List<(int x, int y, bool isFreePoint)>>();
            winPoints.Add("D1", new List<(int x, int y, bool isFreePoint)>());
            winPoints.Add("D2", new List<(int x, int y, bool isFreePoint)>());
            for (int i = 0; i < boardMatrix.Length; i++) {
                checkAndAdd("D1", i, i, opoPlayerSign);
                checkAndAdd("D2", i, boardMatrix[i].Length - 1 - i, opoPlayerSign);

                winPoints.Add("I" + i, new List<(int x, int y, bool isFreePoint)>());
                winPoints.Add("J" + i, new List<(int x, int y, bool isFreePoint)>());

                for (int j = 0; j < boardMatrix[i].Length; j++) {
                    checkAndAdd("I" + i, i, j, opoPlayerSign);
                    checkAndAdd("J" + i, j, i, opoPlayerSign);
                }
            }
            foreach (var winPoint in winPoints) {
                var lastPoint = -1;
                var pointsToWin = 0;
                for (var i = 0; i < winPoint.Value.Count; i++) {
                    if (winPoint.Value[i].isFreePoint) {
                        pointsToWin++;
                        lastPoint = i;
                        _boardPoints[winPoint.Value[i].x, winPoint.Value[i].y] += 0.1;
                    }
                }
                if (pointsToWin == 1) {
                    _boardPoints[winPoint.Value[lastPoint].x, winPoint.Value[lastPoint].y] += 5;
                }
            }
            #endregion

            if (winPoints.Count == 0) {
                for (int i = 0; i < boardMatrix.Length; i++) {
                    for (int j = 0; j < boardMatrix[i].Length; j++) {
                        if (string.IsNullOrEmpty(boardMatrix[i][j])) {
                            _boardPoints[i, j]++;
                        }
                    }
                }
            }
        }
    }
}
