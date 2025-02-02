using System;
using System.Diagnostics;

namespace ReflectionOtusTask;

class Program
{
    static void Main()
    {
        const int firstCount = 100000;
        var serializator = new Serialization();
        var serializeClass = new SomeSerializationClass();

        var timer = new Stopwatch();
        timer.Start();
        for (var i = 0; i < firstCount; i++)
        {
            var serliazationString = serializator.GetString(serializeClass);
        }

        timer.Stop();
        Console.WriteLine(timer.ElapsedMilliseconds);

        var anotherClass = serializeClass.Get();

        timer.Start();
        for (var i = 0; i < firstCount; i++)
        {
            var anotherString = serializator.GetString(anotherClass);
        }

        timer.Stop();
        Console.WriteLine(timer.ElapsedMilliseconds);
    }
}