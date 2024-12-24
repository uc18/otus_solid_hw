using NumberCheckConsole.Interfaces;

namespace NumberCheckConsole.Services;

public class PlayService : IPlayService
{
    private readonly int _randomNumber;
    private int _attempts;
    private int _stateAttempts;
    private readonly ILoggerService _logger;

    public PlayService(int number, int attempts)
    {
        _randomNumber = number;
        _attempts = attempts;
        _logger = new LoggerService();
    }
    public void GameStart()
    {
        _logger.Information("Game started!");
        var gameWasGoing = true;
        do
        {
            _logger.Information("Press number to check");
            var clientNumber = Console.ReadLine();
            if (int.TryParse(clientNumber, out var number))
            {
                if (number > _randomNumber && _stateAttempts != _attempts)
                {
                    _stateAttempts++;
                    _logger.Information($"Your number is greater, attempted {_stateAttempts}");
                    continue;
                }

                if (number < _randomNumber && _stateAttempts != _attempts)
                {
                    _stateAttempts++;
                    _logger.Information($"Your number is lower, attempted {_stateAttempts}");
                    continue;
                }

                if (number == _randomNumber && _stateAttempts != _attempts)
                {
                    gameWasGoing = false;
                    _logger.Information("You're win!");
                    continue;
                }

                if (_attempts == _stateAttempts)
                {
                    _logger.Information("You're not win");
                    gameWasGoing = false;
                }
            }
        } while (gameWasGoing);

        _logger.Information("Game finished!");
    }
}