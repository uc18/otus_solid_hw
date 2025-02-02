using NumberCheckConsole.Interfaces;

namespace NumberCheckConsole.Services;

public class InputService : IInputService
{
    public string GetNumberFromInput()
    {
        var inputNumber = Console.ReadLine();

        return inputNumber != null ? inputNumber : string.Empty;
    }
}