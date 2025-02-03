using System;
using System.Diagnostics;
using System.Text.Json;

namespace ReflectionOtusTask;

class Program
{
    static void Main()
    {
        const int firstCount = 100000;
        var serializator = new InternalSerializator();
        var serializeClass = new SomeSerializationClass();

        var timer = new Stopwatch();
        timer.Start();
        for (var i = 0; i < firstCount; i++)
        {
            var serializationString = serializator.Serialize(serializeClass);
        }

        timer.Stop();

        Console.WriteLine($"First: {timer.ElapsedMilliseconds}");

        var anotherClass = serializeClass.Get();

        timer.Restart();
        for (var i = 0; i < firstCount; i++)
        {
            var anotherString = serializator.Serialize(anotherClass);
        }

        timer.Stop();
        Console.WriteLine($"Second: {timer.ElapsedMilliseconds}");

        timer.Restart();
        for (var i = 0; i < firstCount; i++)
        {
            var deserializeClass = serializator.Deserialize<SomeSerializationClass>("25 15 11 62 25");
        }

        timer.Stop();
        Console.WriteLine($"Third: {timer.ElapsedMilliseconds}");

        timer.Restart();
        var jsonString = string.Empty;
        for (var i = 0; i < firstCount; i++)
        {
            jsonString = JsonSerializer.Serialize(anotherClass);
        }

        timer.Stop();
        Console.WriteLine($"Fourth: {timer.ElapsedMilliseconds}");

        timer.Restart();
        for (var i = 0; i < firstCount; i++)
        {
            var a = JsonSerializer.Deserialize<SomeSerializationClass>(jsonString);
        }

        timer.Stop();
        Console.WriteLine($"Five: {timer.ElapsedMilliseconds}");
    }
}