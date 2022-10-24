using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Console
{
    internal class GameProcessor
    {
        private Point[,] _field;
        private GameState _gameState = GameState.Active;
        private readonly int mineCount;
        private readonly int totalCount;
        private int openCount;

        internal GameProcessor(bool[,] boolField)
        {
            _field = new Point[boolField.GetLength(0), boolField.GetLength(1)];

            for (var row = 0; row < boolField.GetLength(0); row++)
            {
                for (var column = 0; row < boolField.GetLength(1); column++)
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
                _gameState = GameState.Lose;
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
                    _gameState = GameState.Win;
                }
            }

            return _gameState;
        }

        public void SetFlag(int x, int y)
        {
            var targetRow = _field[x, y];
            targetRow.IsFlag = !targetRow.IsFlag;
        }

        public PointState[,] GetCurrentField()
        {

        }

        //public void GenerateField()
        //{
        //    _field = new Point[_sizeX, _sizeY];

        //    for(var row = 0; row < _sizeX; row++)
        //    {
        //        for (var column = 0; row < _sizeX; column++)
        //        {

        //        }
        //    }
        //}
    }

    public class Point
    {
        public bool IsMine { get; set; }

        public bool IsOpen { get; set; }

        public int MineNeighborsCount { get; set; }

        public bool IsFlag { get; set; }
    }

    public enum GameState
    {
        Active,
        Lose,
        Win
    }

    public enum PointState
    {
        Close,
        Flag,
        Neighbors0,
        Neighbors1,
        Neighbors2,
        Neighbors3,
        Neighbors4,
        Neighbors5,
        Neighbors6,
        Neighbors7,
        Neighbors8,
    }
}
