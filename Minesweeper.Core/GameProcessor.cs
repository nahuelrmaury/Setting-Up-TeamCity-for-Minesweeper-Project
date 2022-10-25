using Minesweeper.Core.Enums;

namespace Minesweeper.Core
{
    public class GameProcessor
    {
        private Point[,] _field;
        public GameState GameState { get; private set; } = GameState.Active;
        private readonly int mineCount;
        private readonly int totalCount;
        private int openCount;

        public GameProcessor(bool[,] boolField)
        {
            _field = new Point[boolField.GetLength(0), boolField.GetLength(1)];

            for (var row = 0; row < boolField.GetLength(0); row++)
            {
                for (var column = 0; column < boolField.GetLength(1); column++)
                {
                    bool isMine = boolField[row, column];

                    _field[row, column] = new Point {IsMine = isMine };
                    mineCount = mineCount + (isMine ? 1: 0);
                }
            }

            totalCount = boolField.GetLength(0) * boolField.GetLength(1);
        }

        public GameState Open(int x, int y)
        {
            var targetCell = _field[x, y];
            targetCell.IsOpen = true;

            if (targetCell.IsMine)
            {
                GameState = GameState.Lose;
            }
            else
            {
                int mineNeighborsCount = 0;

                for (var row = y - 1; row <= y + 1; row++)
                {
                    for (var column = x - 1; row <= x + 1; column++)
                    {
                        Point neighbor = _field[row, column];
                        if (neighbor.IsMine)
                        {
                            mineNeighborsCount++;
                        }
                    }
                }

                openCount++;

                if (openCount + mineCount == totalCount)
                {
                    GameState = GameState.Win;
                }
            }

            return GameState;
        }

        public void SetFlag(int x, int y)
        {
            var targetRow = _field[x, y];
            targetRow.IsFlag = !targetRow.IsFlag;
        }

        public PointState[,] GetCurrentField()
        {
            var publicFieldInfo = new PointState[_field.GetLength(0), _field.GetLength(1)];

            for (var row = 0; row < _field.GetLength(0); row++)
            {
                for (var column = 0; column < _field.GetLength(1); column++)
                {
                    var targetCell = _field[row, column];

                    if (!targetCell.IsOpen)
                        publicFieldInfo[row, column] = PointState.Close;
                    else if (targetCell.IsFlag)
                        publicFieldInfo[row, column] = PointState.Flag;
                    else if (targetCell.IsMine)
                        publicFieldInfo[row, column] = PointState.Mine;
                    else
                        publicFieldInfo[row, column] = (PointState)targetCell.MineNeighborsCount;
                }
            }

            return publicFieldInfo;
        }
    }

    public class Point
    {
        public bool IsMine { get; set; }

        public bool IsOpen { get; set; }

        public int MineNeighborsCount { get; set; }

        public bool IsFlag { get; set; }
    }
}
