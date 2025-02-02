namespace NumberCheckConsole.Options;

public record ApplicationRandomNumber
{
    public int AttemptedNumber { get; init; }
    public int RandomNumberMin { get; init; }
    public int RandomNumberMax { get; init; }
}