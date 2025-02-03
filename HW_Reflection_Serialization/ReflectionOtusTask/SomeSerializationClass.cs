using System.Text.Json.Serialization;

namespace ReflectionOtusTask;

public class SomeSerializationClass
{
    [JsonPropertyName("ii")]
    public int i1 { get; set; }

    [JsonPropertyName("i2")]
    public int i2 { get; set; }

    [JsonPropertyName("i3")]
    public int i3 { get; set; }

    [JsonPropertyName("i4")]
    public int i4 { get; set; }

    [JsonPropertyName("i5")]
    public int i5 { get; set; }

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