using NumberCheckConsole.Interfaces;

namespace NumberCheckConsole.Services;

public class LoggerService : ILoggerService
{
    public void Information(string message)
    {
        Console.WriteLine(message);
    }
}