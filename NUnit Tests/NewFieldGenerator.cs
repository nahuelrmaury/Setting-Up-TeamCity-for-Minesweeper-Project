using Minesweeper.Core;
using Minesweeper.Core.Enums;
using Minesweeper.Core.Models;
using NUnit.Framework;
using System.Data.Common;

namespace MineSweeper.PositiveUnitTests
{
    public class NewFieldGenerator
    {
        public bool[,] FieldGenerator(int rows, int columns, int mines)
        {
            bool[,] newField = new bool[rows, columns];
            int minesAmount = mines;

            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < columns; k++)
                {
                    if (mines > 0)
                    {
                        newField[j, k] = true;
                        mines--;
                    }
                    else
                    {
                        newField[j, k] = false;
                    }
                    if (j == 1 && k == 1 && minesAmount > 4)
                    {
                        newField[j, k] = false;
                        mines++;
                    }
                }
            }

            return newField;
        }
    }
}


