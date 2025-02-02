using NumberCheckConsole.Extension;
using NumberCheckConsole.Interfaces;
using NumberCheckConsole.Options;
using NumberCheckConsole.Services;

namespace NumberCheckConsole;

class Program
{
    static void Main()
    {
        var configuration = ConfigurationExtension.GetConfiguration();

        var applicationOptions =
            ConfigurationExtension.GetOptions<ApplicationRandomNumber>(configuration, nameof(ApplicationRandomNumber));

        IRandomGeneratorService randomService = new RandomGeneratorService(applicationOptions.RandomNumberMin, applicationOptions.RandomNumberMax);
        var randomNumberForGame = randomService.GetRandomNumber();
        IPlayService game = new PlayService(randomNumberForGame, applicationOptions.AttemptedNumber);
        game.GameStart();
    }
}