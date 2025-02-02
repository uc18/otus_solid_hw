namespace ReflectionOtusTask;

public class SomeSerializationClass
{
    public int i1;
    public int i2;
    public int i3;
    public int i4;
    public int i5;

    public SomeSerializationClass Get()
    {
        return new SomeSerializationClass
        {
            i1 = 1,
            i2 = 2,
            i3 = 3,
            i4 = 4,
            i5 = 5
        };
    }
}