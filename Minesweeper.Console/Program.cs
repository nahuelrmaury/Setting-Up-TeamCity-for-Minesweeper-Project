using Minesweeper.Core;
using Minesweeper.Core.Enums;

var dict = new Dictionary<PointState, char>() 
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

var randomizer = new FieldGenerator();

var field = randomizer.GetRandomField(9, 9, 10);

var gameProcessor = new GameProcessor(field);

var currentField = gameProcessor.GetCurrentField();

Print(currentField);

while (gameProcessor.GameState == GameState.Active)
{
    Console.WriteLine("Enter coordinates");

    var x = int.Parse(Console.ReadLine());
    var y = int.Parse(Console.ReadLine());

    var currentState = gameProcessor.Open(x, y);
    currentField = gameProcessor.GetCurrentField();
    Console.Clear();
    Print(currentField);
}

Console.WriteLine(gameProcessor.GameState ==  GameState.Lose ? "GAME IS OVER" : "YOU WIN!");

Console.ReadKey();

void Print(PointState[,] field)
{
    for (var row = 0; row < field.GetLength(0); row++)
    {
        for (var column = 0; column < field.GetLength(1); column++)
        {
            Console.Write(dict[field[row, column]]);
        }

        Console.WriteLine();
    }
}
