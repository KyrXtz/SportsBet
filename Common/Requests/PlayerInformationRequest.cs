namespace SportsBet.Common.Requests;

#region XML

[XmlRoot(ElementName = "player_list")]
public class PlayerInformationListXmlRequest
{
    [XmlElement(ElementName = "player")]
    public List<PlayerInformationXml> Players { get; set; }

    [XmlAttribute(AttributeName = "date_generated")]
    public string DateGenerated { get; set; }

    [XmlAttribute(AttributeName = "pusher_id")]
    public string PusherId { get; set; }
}

[XmlRoot(ElementName = "player")]
public class PlayerInformationXml
{

    [XmlElement(ElementName = "team_player")]
    public List<PlayerInformationLineupXml> Lineup { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public string Id { get; set; }

    [XmlAttribute(AttributeName = "match_name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "country_id")]
    public string CountryId { get; set; }

    [XmlAttribute(AttributeName = "country")]
    public string Country { get; set; }

    [XmlAttribute(AttributeName = "position_id")]
    public string PositionId { get; set; }

    [XmlAttribute(AttributeName = "position")]
    public string Position { get; set; }

    [XmlAttribute(AttributeName = "changetime")]
    public DateTime Changetime { get; set; }
}

[XmlRoot(ElementName = "team_player")]
public class PlayerInformationLineupXml
{

    [XmlAttribute(AttributeName = "team_id")]
    public string CompetitorId { get; set; }

    [XmlAttribute(AttributeName = "rating_id")]
    public string RatingId { get; set; }

    [XmlAttribute(AttributeName = "rating")]
    public string Rating { get; set; }

    [XmlAttribute(AttributeName = "jersey_number")]
    public string JerseyNumber { get; set; }
}

#endregion

#region JSON
public record PlayerInformationListJsonRequest(
    [property: JsonProperty("player_list")] PlayerInformationListJson PlayerList
);

public record PlayerInformationListJson(
    [property: JsonProperty("player")] List<PlayerInformationJson> Players,
    [property: JsonProperty("date_generated")] long DateGenerated,
    [property: JsonProperty("pusher_id")] int PusherId
);

public record PlayerInformationJson(
    [property: JsonProperty("team_player")] List<PlayerInformationLineupJson> Lineup,
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("match_name")] string Name,
    [property: JsonProperty("country_id")] int CountryId,
    [property: JsonProperty("country")] string Country,
    [property: JsonProperty("position_id")] int PositionId,
    [property: JsonProperty("position")] string Position,
    [property: JsonProperty("changetime")] long Changetime
);

public record PlayerInformationLineupJson(
    [property: JsonProperty("team_id")] int CompetitorId,
    [property: JsonProperty("rating_id")] int RatingId,
    [property: JsonProperty("rating")] string Rating,
    [property: JsonProperty("jersey_number")] int JerseyNumber
);
#endregion