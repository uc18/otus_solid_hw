using Microsoft.Extensions.Options;
using NumberCheck.Interfaces;

namespace NumberCheck.Services;

public class RandomGeneratorService : IRandomGeneratorService
{
    private readonly int _randomNumber;
    public RandomGeneratorService(IOptions<ApplicationRandomNumber> options)
    {
        var random = new Random();
        _randomNumber = random.Next(options.Value.RandomNumberMin, options.Value.RandomNumberMax);
    }
    public int GetRandomNumber()
    {
        return _randomNumber;
    }
}