using NumberCheckConsole.Interfaces;

namespace NumberCheckConsole.Services;

public class PlayService : IPlayService
{
    private readonly int _randomNumber;
    private int _attempts;
    private int _stateAttempts;
    public PlayService(int number, int attempts)
    {
        _randomNumber = number;
        _attempts = attempts;
    }
    public void GameStart()
    {
        Console.WriteLine("Game started!");
        Console.WriteLine("Press any key to continue...");
        var gameWasGoing = true;
        do
        {
            var a = Console.ReadLine();
            if (int.TryParse(a, out var number))
            {
                if (number > _randomNumber && _stateAttempts != _attempts)
                {
                    _stateAttempts++;
                    Console.WriteLine($"Your number is greater, attempted {_attempts}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (number < _randomNumber && _stateAttempts != _attempts)
                {
                    _stateAttempts++;
                    Console.WriteLine($"Your number is lower, attempted {_attempts}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (number == _randomNumber && _stateAttempts != _attempts)
                {
                    gameWasGoing = false;
                }

                if (_attempts == _stateAttempts)
                {
                    gameWasGoing = false;
                }
            }
        } while (gameWasGoing);

        Console.WriteLine("Game finished!");
    }
}