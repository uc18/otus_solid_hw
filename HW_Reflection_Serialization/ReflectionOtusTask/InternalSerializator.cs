using System.Text;

namespace ReflectionOtusTask;

public class InternalSerializator
{
    public string Serialize<T>(T obj)
    {
        if (obj != null)
        {
            var type = obj.GetType();

            var typeFields = type.GetFields();
            var typeProperties = type.GetProperties();
            var sb = new StringBuilder();

            if (typeFields.Length > 0)
            {
                foreach (var field in typeFields)
                {
                    var reflectionValue = field.GetValue(obj);

                    sb.AppendLine($"Field name: {field.Name}, value: {reflectionValue ?? string.Empty}");
                }

                return sb.ToString();
            }

            if (typeProperties.Length > 0)
            {
                foreach (var property in typeProperties)
                {
                    var reflectionValue = property.GetValue(obj);

                    sb.AppendLine($"Field name: {property.Name}, value: {reflectionValue ?? string.Empty}");
                }

                return sb.ToString();
            }
        }


        return string.Empty;
    }

    public T Deserialize<T>(string input) where T : class, new()
    {
        var type = typeof(T);
        var deserializeObject = new T();
        if (!string.IsNullOrEmpty(input))
        {
            var charArray = input.Split(" ");
            var fields = type.GetFields();

            if (charArray.Length == fields.Length)
            {
                for (var i = 0; i < charArray.Length; i++)
                {
                    if (int.TryParse(charArray[i], out var parsedValue))
                    {
                        fields[i].SetValue(deserializeObject, parsedValue);
                    }
                }

                return deserializeObject;
            }
        }

        return deserializeObject;
    }
}