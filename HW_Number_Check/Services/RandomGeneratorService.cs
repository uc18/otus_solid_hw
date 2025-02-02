using NumberCheckConsole.Interfaces;


namespace NumberCheckConsole.Services;

public class RandomGeneratorService : IRandomGeneratorService
{
    private readonly int _randomNumber;
    public RandomGeneratorService(int minNumber, int maxNumber)
    {
        var random = new Random();
        _randomNumber = random.Next(minNumber, maxNumber);
    }
    public int GetRandomNumber()
    {
        return _randomNumber;
    }
}