using Minesweeper.Console;
using Minesweeper.Core;
using Minesweeper.Core.Enums;
using NUnit.Framework;


namespace Tests;

[TestFixture]

internal class Test
{
    public Boolean[,] _minePosition;


    [SetUp]
    public void SetUp()
    {
        _minePosition = new Boolean[3, 3];
    }


    [Test]

    public void GameStateOpen_GameStatePerformanceAsActive_GamesStateIsActive()
    {
        _minePosition[0, 0] = true;
        _minePosition[1, 1] = true;
        _minePosition[2, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gamestate = _gameProcessor.Open(0, 1);
        Assert.That(gamestate == GameState.Active);

    }

    [Test]
    public void GameStateOpen_GameStatePerformanceAsActiveAfterSamePointClicking_GamesStateIsActive()
    {
        _minePosition[0, 0] = true;
        _minePosition[1, 1] = true;
        _minePosition[2, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gamestate1 = _gameProcessor.Open(0, 1);
        var gamestate2 = _gameProcessor.Open(0, 1);
        Assert.That(gamestate1 == GameState.Active);
        Assert.That(gamestate2 == GameState.Active);

    }

    [Test]

    public void GameStateOpen_GameStatePerformanceAsLose_GamesStateIsLose()
    {

        _minePosition[0, 0] = true;
        _minePosition[1, 1] = true;
        _minePosition[2, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gamestate = _gameProcessor.Open(0, 0);
        Assert.That(gamestate == GameState.Lose);

    }
    [Test]
    public void GameStateOpen_GameStatePerformanceAfterInvalidOperationIfGameStateIsLose_ThrowExeptionIfGameStateNotActive()
    {
        _minePosition[0, 0] = true;
        _minePosition[1, 1] = true;
        _minePosition[2, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gamestate = _gameProcessor.Open(0, 0);
        if (gamestate == GameState.Lose)
        {
            Assert.Throws<InvalidOperationException>(() => _gameProcessor.Open(0, 0));
        }

    }

    [Test]
    public void GameStateOpen_GameStatePerformanceAfterInvalidOperationIfGameStateIsWin_ThrowExeptionIfGameStateNotActive()
    {
        _minePosition[0, 1] = true;
        _minePosition[0, 2] = true;
        _minePosition[1, 2] = true;
        _minePosition[1, 0] = true;
        _minePosition[0, 0] = true;
        _minePosition[2, 2] = true;
        _minePosition[2, 1] = true;
        _minePosition[2, 0] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gamestate = _gameProcessor.Open(1, 1);
        if (gamestate == GameState.Win)
        {
            Assert.Throws<InvalidOperationException>(() => _gameProcessor.Open(1, 1));
        }

    }
    [Test]
    public void GameProcessorOpen_GameStatePerformanceAsWin_GamesIsWin()
    {
        _minePosition[0, 1] = true;
        _minePosition[0, 2] = true;
        _minePosition[1, 2] = true;
        _minePosition[1, 0] = true;
        _minePosition[0, 0] = true;
        _minePosition[2, 2] = true;
        _minePosition[2, 1] = true;
        _minePosition[2, 0] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gamestate = _gameProcessor.Open(1, 1);
        Assert.That(gamestate == GameState.Win);

    }

    [Test]
    public void GameProcessorGetCurrentField_OpenMinCell_OpenedCellIsMine()
    {
        _minePosition[0, 0] = true;
        _minePosition[1, 1] = true;
        _minePosition[2, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(0, 0);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[0, 0] == PointState.Mine);
       

    }
    [Test]
    public void GameProcessorGetCurrentField_OpenCellWithZeroNeighbor_OpenedCellHasZeroNeighbor()
    {

        _minePosition[0, 0] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(2, 1);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[1, 2] == PointState.Neighbors0);
    }
        

    [Test]

    public void GameProcessorGetCurrentField_OpenCellWithOneNeighbor_OpenedCellHasOneNeighbor()
    {
        _minePosition[0, 0] = true;
        _minePosition[1, 1] = true;
        _minePosition[2, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(0, 2);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[2, 0] == PointState.Neighbors1);
    }


    [Test]
    public void GameProcessorGetCurrentField_OpenCellWithTwoNeighbors_OpenedCellHaveTwoNeighbors()
    {
        _minePosition[0, 0] = true;
        _minePosition[1, 1] = true;
        _minePosition[2, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(0, 1);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[1, 0] == PointState.Neighbors2);
    }

    [Test]
    public void GameProcessorGetCurrentField_OpenCellWithThreeNeighbors_OpenedCellHaveThreeNeighbors()
    {
        _minePosition[0, 1] = true;
        _minePosition[0, 2] = true;
        _minePosition[1, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(1, 1);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[1, 1] == PointState.Neighbors3);
    }
    [Test]
    public void GameProcessorGetCurrentField_OpenCellWithFourNeighbors_OpenedCellHaveFourNeighbors()
    {
        _minePosition[0, 1] = true;
        _minePosition[0, 2] = true;
        _minePosition[1, 2] = true;
        _minePosition[1, 0] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(1, 1);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[1, 1] == PointState.Neighbors4);
    }

    [Test]
    public void GameProcessorGetCurrentField_OpenCellWithFiveNeighbors_OpenedCellHaveFiveNeighbors()
    {
        _minePosition[0, 1] = true;
        _minePosition[0, 2] = true;
        _minePosition[1, 2] = true;
        _minePosition[1, 0] = true;
        _minePosition[0, 0] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(1, 1);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[1, 1] == PointState.Neighbors5);
    }

    [Test]
    public void GameProcessorGetCurrentField_OpenCellWithSixNeighbors_OpenedCellHaveSixNeighbors()
    {
        _minePosition[0, 1] = true;
        _minePosition[0, 2] = true;
        _minePosition[1, 2] = true;
        _minePosition[1, 0] = true;
        _minePosition[0, 0] = true;
        _minePosition[2, 2] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(1, 1);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[1, 1] == PointState.Neighbors6);
    }
    [Test]
    public void GameProcessorGetCurrentField_OpenCellWithSevenNeighbors_OpenedCellHaveSevenNeighbors()
    {
        _minePosition[0, 1] = true;
        _minePosition[0, 2] = true;
        _minePosition[1, 2] = true;
        _minePosition[1, 0] = true;
        _minePosition[0, 0] = true;
        _minePosition[2, 2] = true;   
        _minePosition[2, 1] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(1, 1);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[1, 1] == PointState.Neighbors7);
    }
    [Test]
    public void GameProcessorGetCurrentField_OpenCellWithEightNeighbors_OpenedCellHaveEightNeighbors()
    {
        _minePosition[0, 1] = true;
        _minePosition[0, 2] = true;
        _minePosition[1, 2] = true;
        _minePosition[1, 0] = true;
        _minePosition[0, 0] = true;
        _minePosition[2, 2] = true;
        _minePosition[2, 1] = true;
        _minePosition[2, 0] = true;
        GameProcessor _gameProcessor = new GameProcessor(_minePosition);
        var gameState = _gameProcessor.Open(1, 1);
        var currentField = _gameProcessor.GetCurrentField();
        Assert.That(currentField[1, 1] == PointState.Neighbors8);
    }

}


