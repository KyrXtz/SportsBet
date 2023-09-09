using System.ComponentModel.DataAnnotations;

namespace SportsBet.Common.Requests;

#region XML

[XmlRoot(ElementName = "keep_alive")]
public class KeepAliveXmlRequest
{
    [XmlAttribute(AttributeName = "date_generated")]
    public string DateGenerated { get; set; }

    [XmlAttribute(AttributeName = "pusher_id")]
    public string PusherId { get; set; }
}

#endregion

#region JSON

public record KeepAliveJsonRequest(
    [property: JsonProperty("keep_alive")] KeepAliveJson KeepAlive
);

public record KeepAliveJson(
    [property: JsonProperty("date_generated")] long DateGenerated,
    [property: JsonProperty("pusher_id")] int PusherId
);

#endregion