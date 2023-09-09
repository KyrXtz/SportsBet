namespace SportsBet.Common.Helpers;

public static class UnifiedProviderHelperMethods
{
    public static string GetCompositeId<T>(string prefix, T key) => $"{prefix}-{key}";

    public static T GetKey<T>(string compositeKey)
    {
        var parts = compositeKey.Split('-').ToArray();
        var converter = TypeDescriptor.GetConverter(typeof(T));
        return (T)converter.ConvertFrom(parts[1]);
    }
}