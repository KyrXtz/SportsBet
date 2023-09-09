namespace SportsBet.Common.Helpers;

public static class StringConverters
{
    public static T? FromJson<T>(this string value)
    {
        return JsonConvert.DeserializeObject<T>(value);
    }
    
    public static T? FromXml<T>(this string value)
    {
        using TextReader reader = new StringReader(value);
        var xmlSerializer = new XmlSerializer(typeof(T));
        var xmlModel = (T?)xmlSerializer.Deserialize(new IgnoreNamespaceXmlTextReader(reader));
        return xmlModel;
    }
}

class IgnoreNamespaceXmlTextReader : XmlTextReader
{
    public IgnoreNamespaceXmlTextReader(TextReader reader) : base(reader) 
    { 
    }
 
    public override string NamespaceURI => "";
}