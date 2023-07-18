using Minesweeper.Core;
using Minesweeper.Core.Enums;
using Minesweeper.Core.Models;
using NUnit.Framework;
using System.Data.Common;

namespace MineSweeper.PositiveUnitTests
{
    [TestFixture]
    public class OpenMethodTests
    {
        /* _gameProcessor is a reference to an instance of the Minesweeper.Core class */
        private GameProcessor _gameProcessor;
        /* boolean array that stores the state of the cells */
        private bool[,] _field;
        /* instance to generate a boolean field for testing purposes */
        private NewFieldGenerator _newField = new NewFieldGenerator();


        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void PostCondition()
        {
        }

        /* these tests methods ensures that the Open method behaves correctly under different scenarios */
        /* Is GameState instance of GameProcessor?  */
        [Test]
        /* define five arguments as data input for each test cases */
        /* cordinate x - cordinate y - rows - columns - mines quantity */
        [TestCase(0, 0, 9, 9, 10)] /* beginner */
        [TestCase(5, 5, 16, 16, 40)] /* intermediate */
        [TestCase(10, 10, 16, 30, 99)] /* expert */
        [TestCase(10, 10, 20, 20, 400)] /* random size */
        public void T1_RandomFieldGenerator_OpenCellWithMinesAndNeighbors_GameStateObjectIsInstanceOfGameProcessor(int x, int y, int row, int column, int mines)
        {
            /* precondition */
            _field = FieldGenerator.GetRandomField(row, column, mines);

            /* action */
            _gameProcessor = new GameProcessor(_field);

            /* assert */
            Assert.IsInstanceOf<GameState>(_gameProcessor.Open(x, y));
        }

        /* test to compare actual gameState (win or lose) vs gameStateExpected  */
        [Test]
        /* cordinate x - cordinate y - game state - rows - columns - mines quantity */
        [TestCase(5, 5, GameState.Win, 9, 9, 0)] /* beginner win */
        [TestCase(5, 5, GameState.Win, 16, 16, 0)] /* intermediate win */
        [TestCase(5, 5, GameState.Win, 16, 30, 0)] /* expert win */
        [TestCase(5, 5, GameState.Lose, 9, 9, 81)] /* beginner lose */
        [TestCase(5, 5, GameState.Lose, 16, 16, 256)] /* intermediate lose */
        [TestCase(5, 5, GameState.Lose, 16, 30, 480)] /* expert lose */
        public void T2_RandomFieldGenerator_OpenCellToWinOrLoseWithEverySizePosible_ReturnGameState(int x, int y, GameState gameStateExpected, int row, int column, int mines)
        {
            /* precondition */
            _field = FieldGenerator.GetRandomField(row, column, mines);
            _gameProcessor = new GameProcessor(_field);

            /* action */
            GameState gameState = _gameProcessor.Open(x, y);

            /* assert */
            Assert.AreEqual(gameState, gameStateExpected);
        }

        /* verifies that GameProcessor object correctly throws an InvalidOperationException  */
        [Test]
        [TestCase(5, 5, 9, 9, 0)] /* beginner open cell after win */
        [TestCase(10, 10, 16, 16, 0)] /* intermediate open cell after win */
        [TestCase(5, 5, 16, 30, 0)] /* expert open cell after win */
        [TestCase(5, 5, 9, 9, 81)] /* beginner open cell after lose */
        [TestCase(10, 10, 16, 16, 256)] /* intermediate open cell after lose */
        [TestCase(5, 5, 16, 30, 480)] /* expert open cell after lose */
        public void T3_RandomFieldGenerator_OpenCellAfterWinAndLoseWithEverySizePosible_ThrowException(int x, int y, int row, int column, int mines)
        {
            /* precondition */
            _field = FieldGenerator.GetRandomField(row, column, mines);
            _gameProcessor = new GameProcessor(_field);

            /* action */
            _gameProcessor.Open(x, y);

            /* assert */
            Assert.Throws<InvalidOperationException>(() => _gameProcessor.Open(x, y));
        }

        /* verifies if the game state is active after open one cell without a mine  */
        [Test]
        [TestCase(1, 1, 3, 3, 4)]
        public void T4_FieldGenerated_OpenCellWithNeighborsAndNoMines_ReturnExpectedGameState(int x, int y, int rows, int columns, int mines)
        {
            /* precondition */
            _field = _newField.FieldGenerator(rows, columns, mines);
            _gameProcessor = new GameProcessor(_field);
            GameState expectedGameState = GameState.Active;
            GameState actualGameState;

            /* action */
            actualGameState = _gameProcessor.Open(x, y);

            /* assert */
            Assert.AreEqual(expectedGameState, actualGameState);
        }
    }
}
