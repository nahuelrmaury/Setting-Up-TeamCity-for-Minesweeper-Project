using Minesweeper.Core;
using Minesweeper.Core.Enums;
using Minesweeper.Core.Models;

var consoleSymbolByPointState = new Dictionary<PointState, char>()
{
    [PointState.Close] = 'D',
    [PointState.Mine] = '*',
    [PointState.Neighbors0] = '-',
    [PointState.Neighbors1] = '1',
    [PointState.Neighbors2] = '2',
    [PointState.Neighbors3] = '3',
    [PointState.Neighbors4] = '4',
    [PointState.Neighbors5] = '5',
    [PointState.Neighbors6] = '6',
    [PointState.Neighbors7] = '7',
    [PointState.Neighbors8] = '8',
};

Console.WriteLine("Choose difficulty level (Begginer|Intermediate|Expert):");

DifficultyLevel difficultyLevel = Enum.Parse<DifficultyLevel>(Console.ReadLine());
GameSettings settings = DifficultyManager.GetGameSettingsByDifficultylevel(difficultyLevel);

var field = FieldGenerator.GetRandomField(settings.Width, settings.Height, settings.Mines);

var gameProcessor = new GameProcessor(field);

var currentField = gameProcessor.GetCurrentField();

Print(currentField);

while (gameProcessor.GameState == GameState.Active)
{
    Console.WriteLine("Enter coordinate X");
    var x = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter coordinate Y");
    var y = int.Parse(Console.ReadLine());

    gameProcessor.Open(x, y);
    currentField = gameProcessor.GetCurrentField();
    //Console.Clear();
    Print(currentField);
}

Console.WriteLine(gameProcessor.GameState == GameState.Lose ? "GAME IS OVER" : "YOU WIN!");

Console.ReadKey();

void Print(PointState[,] field)
{
    Console.Clear();

    for (var row = field.GetLength(0) - 1; row >= 0; row--)
    {
        Console.Write($"{row} ");
        for (var column = 0; column < field.GetLength(1); column++)
        {
            Console.Write(consoleSymbolByPointState[field[row, column]]);
        }

        Console.WriteLine();
    }

    Console.Write("  ");

    for (var column = 0; column < field.GetLength(1); column++)
    {
        Console.Write(column);
    }

    Console.WriteLine();
}
