using System.Text;

namespace ReflectionOtusTask;

public class Serialization
{
    public string GetString<T>(T obj)
    {
        if (obj != null)
        {
            var type = obj.GetType();

            var typeFields = type.GetFields();
            var sb = new StringBuilder();

            foreach (var field in typeFields)
            {
                sb.Append(field.Name);
            }

            return sb.ToString();
        }


        return string.Empty;
    }
}