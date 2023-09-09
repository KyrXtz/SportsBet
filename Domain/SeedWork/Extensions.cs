namespace SportsBet.Domain.SeedWork;
public static class Extensions
{
    public static void AddUniqueItem<T>(this List<T> list, T item)
    {
        if (!list.Contains(item))
            list.Add(item);
    }

    public static int ToIntOrDefault(this string input, int defaultValue = 0)
    {
        int result;
        if (int.TryParse(input, out result))
            return result;
        else
            return defaultValue;
    }

    public static DateTime ToDateTimeOrDefault(this string input)
    {
        return ToDateTimeOrDefault(input, DateTime.MinValue);
    }

    public static DateTime ToDateTimeOrDefault(this string input, DateTime defaultValue)
    {
        DateTime result;
        if (DateTime.TryParse(input, out result))
            return result;
        else
            return defaultValue;
    }

    public static bool ToBoolOrDefault(this string input, bool defaultValue = false)
    {
        bool result;
        if (bool.TryParse(input, out result))
            return result;
        else
            return defaultValue;
    }

    public static Dictionary<string, string> ToKeyValueDictionary<T>(this T instance)
    {
        return ToKeyValueDictionary(instance, new List<string>());
    }
    public static Dictionary<string, string> ToKeyValueDictionary<T>(this T instance, List<string> filterFields)
    {
        var settings = new JsonSerializerSettings { Formatting = Formatting.Indented };
        var properties = typeof(T).GetProperties();

        return properties.ToDictionary(
            prop => prop.GetCustomAttributes(typeof(JsonPropertyAttribute), false)
                        .OfType<JsonPropertyAttribute>()
                        .FirstOrDefault(p => filterFields.Contains(p?.PropertyName))?.PropertyName ?? prop.Name,
            prop => prop.PropertyType == typeof(string) ?
                    (prop.GetValue(instance)?.ToString() ?? string.Empty) :
                    JsonConvert.SerializeObject(prop.GetValue(instance), settings)
        );
    }
}