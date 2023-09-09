namespace SportsBet.Common.Requests;

#region XML
[XmlRoot(ElementName = "event_list")]
public class MatchEventListXmlRequest
{

    [XmlElement(ElementName = "event")]
    public List<MatchEventListItemXml> Events { get; set; }

    [XmlAttribute(AttributeName = "date_generated")]
    public string DateGenerated { get; set; }

    [XmlAttribute(AttributeName = "pusher_id")]
    public string PusherId { get; set; }
}

[XmlRoot(ElementName = "event")]
public class MatchEventListItemXml
{
    [XmlAttribute(AttributeName = "matchid")]
    public string MatchId { get; set; }

    [XmlAttribute(AttributeName = "minute")]
    public string Minute { get; set; }
    [XmlAttribute(AttributeName = "seconds")]
    public string Seconds { get; set; }

    [XmlAttribute(AttributeName = "event_number")]
    public string EventNumber { get; set; }

    [XmlAttribute(AttributeName = "event_code_id")]
    public string EventCodeId { get; set; }

    [XmlAttribute(AttributeName = "date")]
    public string Date { get; set; }

    [XmlAttribute(AttributeName = "event_code")]
    public string EventCode { get; set; }

    [XmlAttribute(AttributeName = "tickerstate_id")]
    public string TickerstateId { get; set; }

    [XmlAttribute(AttributeName = "tickerstate")]
    public string Tickerstate { get; set; }

    [XmlAttribute(AttributeName = "score_home")]
    public string ScoreHome { get; set; }

    [XmlAttribute(AttributeName = "score_away")]
    public string ScoreAway { get; set; }

    [XmlAttribute(AttributeName = "related_events")]
    public string RelatedEventsIds { get; set; }

    [XmlAttribute(AttributeName = "statistics")]
    public string Statistics { get; set; }

    [XmlAttribute(AttributeName = "currentPlaytime")]
    public string CurrentPlaytime { get; set; }

    [XmlAttribute(AttributeName = "clockRunning")]
    public string ClockRunning { get; set; }

    [XmlAttribute(AttributeName = "value_event_data")]
    public string ValueEventData { get; set; }

    [XmlAttribute(AttributeName = "team_id")]
    public string CompetitorId { get; set; }

    [XmlAttribute(AttributeName = "score")]
    public string Score { get; set; }

    [XmlAttribute(AttributeName = "clears_event")]
    public string ClearsEventsIds { get; set; }

    [XmlAttribute(AttributeName = "related_event_codes")]
    public string RelatedEventCodes { get; set; }

    [XmlAttribute(AttributeName = "cancel_event_code_ids")]
    public string CancelEventCodeIds { get; set; }

    [XmlAttribute(AttributeName = "cancel_minutes")]
    public string CancelMinutes { get; set; }

    [XmlAttribute(AttributeName = "cancel_game_times")]
    public string CancelGameTimes { get; set; }

    [XmlAttribute(AttributeName = "timestamp")]
    public string Timestamp { get; set; }

    [XmlAttribute(AttributeName = "player_id")]
    public string PlayerId { get; set; }

    [XmlAttribute(AttributeName = "player_num")]
    public string PlayerNum { get; set; }

    [XmlAttribute(AttributeName = "player_name")]
    public string PlayerName { get; set; }

    [XmlAttribute(AttributeName = "event_reason")]
    public string EventReason { get; set; }

    [XmlAttribute(AttributeName = "event_reason_id")]
    public string EventReasonId { get; set; }

    [XmlAttribute(AttributeName = "message")]
    public string Message { get; set; }

    [XmlAttribute(AttributeName = "message_id")]
    public string MessageId { get; set; }

    [XmlAttribute(AttributeName = "attendance_id")]
    public string AttendanceId { get; set; }

    [XmlAttribute(AttributeName = "attendance")]
    public string Attendance { get; set; }

    [XmlAttribute(AttributeName = "pitch_condition_id")]
    public string PitchConditionId { get; set; }

    [XmlAttribute(AttributeName = "pitch_condition")]
    public string PitchCondition { get; set; }

    [XmlAttribute(AttributeName = "weather_condition_id")]
    public string WeatherConditionId { get; set; }

    [XmlAttribute(AttributeName = "weather_condition")]
    public string WeatherCondition { get; set; }

    [XmlAttribute(AttributeName = "zone")]
    public string Zone { get; set; }

    [XmlAttribute(AttributeName = "player_in_num")]
    public string PlayerInNum { get; set; }

    [XmlAttribute(AttributeName = "player_out_num")]
    public string PlayerOutNum { get; set; }

    [XmlAttribute(AttributeName = "player_in_id")]
    public string PlayerInId { get; set; }

    [XmlAttribute(AttributeName = "player_out_id")]
    public string PlayerOutId { get; set; }

    [XmlAttribute(AttributeName = "stoppage_time")]
    public string StoppageTime { get; set; }

    [XmlElement(ElementName = "lineups")]
    public List<MatchEventLineupXml> Lineups { get; set; }

}
[XmlRoot(ElementName = "lineups")]
public class MatchEventLineupXml
{
    [XmlAttribute(AttributeName = "squad_type")]
    public string SquadType { get; set; }

    [XmlAttribute(AttributeName = "squad_type_id")]
    public string SquadTypeId { get; set; }

    [XmlAttribute(AttributeName = "team_name")]
    public string CompetitorName { get; set; }

    [XmlAttribute(AttributeName = "team_id")]
    public string CompetitorId { get; set; }

    [XmlElement(ElementName = "lineup")]
    public List<MatchEventLineupPlayerXml> LineupPlayers { get; set; }
}

[XmlRoot(ElementName = "lineup")]
public class MatchEventLineupPlayerXml
{
    [XmlAttribute(AttributeName = "jersey_number")]
    public string JerseyNumber { get; set; }

    [XmlAttribute(AttributeName = "match_name")]
    public string PlayerName { get; set; }

    [XmlAttribute(AttributeName = "player_id")]
    public string PlayerId { get; set; }
}
#endregion

#region JSON
public record MatchEventListJsonRequest(
    [property: JsonProperty("event_list")] MatchEventListJson EventList
);

public record MatchEventListJson(
    [property: JsonProperty("event")] List<MatchEventListItemJson> Events,
    [property: JsonProperty("date_generated")] long DateGenerated,
    [property: JsonProperty("pusher_id")] int PusherId
);

public record MatchEventLineupJson(
    [property: JsonProperty("squad_type")] string SquadType,
    [property: JsonProperty("squad_type_id")] int SquadTypeId,
    [property: JsonProperty("team_name")] string CompetitorName,
    [property: JsonProperty("team_id")] int CompetitorId,
    [property: JsonProperty("lineup")] List<MatchEventLineupPlayerJson> LineupPlayers
);

public record MatchEventLineupPlayerJson(
    [property: JsonProperty("jersey_number")] int JerseyNumber,
    [property: JsonProperty("match_name")] string PlayerName,
    [property: JsonProperty("player_id")] int PlayerId
);

public record MatchEventListItemJson(
    [property: JsonProperty("game_id")] int MatchId,
    [property: JsonProperty("matchid")] int Matchid, //???
    [property: JsonProperty("minute")] int Minute,
    [property: JsonProperty("event_number")] string EventNumber,
    [property: JsonProperty("event_code_id")] int EventCodeId,
    [property: JsonProperty("date")] long Date,
    [property: JsonProperty("event_code")] string EventCode,
    [property: JsonProperty("tickerstate_id")] int MatchStateId,
    [property: JsonProperty("tickerstate")] string MatchState,
    [property: JsonProperty("score_home")] int ScoreHome,
    [property: JsonProperty("score_away")] int ScoreAway,
    [property: JsonProperty("seconds")] int Seconds,
    [property: JsonProperty("currentPlaytime")] long CurrentPlaytime,
    [property: JsonProperty("clockRunning")] bool ClockRunning,
    [property: JsonProperty("score")] List<string> Score,
    [property: JsonProperty("value_event_data")] string ValueEventData,
    [property: JsonProperty("statistics")] List<string> Statistics,
    [property: JsonProperty("team_id")] string CompetitorId,
    [property: JsonProperty("related_events")] List<int> RelatedEventsIds,
    [property: JsonProperty("clears_event")] List<int> ClearsEventsIds,
    [property: JsonProperty("related_event_codes")] List<string> RelatedEventCodes, //????
    [property: JsonProperty("cancel_event_code_ids")] List<string> CancelEventCodeIds, //maybe deprecated
    [property: JsonProperty("cancel_minutes")] List<int> CancelMinutes, //maybe deprecated
    [property: JsonProperty("cancel_game_times")] List<int> CancelGameTimes, //maybe deprecated
    [property: JsonProperty("timestamp")] long Timestamp,
    [property: JsonProperty("player_id")] int PlayerId,
    [property: JsonProperty("player_num")] int PlayerNum,
    [property: JsonProperty("player_name")] string PlayerName,
    [property: JsonProperty("event_reason")] string EventReason,
    [property: JsonProperty("event_reason_id")] int EventReasonId,
    [property: JsonProperty("lineups")] List<MatchEventLineupJson> Lineups,
    [property: JsonProperty("message")] string Message,
    [property: JsonProperty("message_id")] int MessageId,
    [property: JsonProperty("attendance_id")] int AttendanceId,
    [property: JsonProperty("attendance")] string Attendance,
    [property: JsonProperty("pitch_condition_id")] int PitchConditionId,
    [property: JsonProperty("pitch_condition")] string PitchCondition,
    [property: JsonProperty("weather_condition_id")] int WeatherConditionId,
    [property: JsonProperty("weather_condition")] string WeatherCondition,
    [property: JsonProperty("zone")] string Zone,
    [property: JsonProperty("player_in_num")] int PlayerInNum,
    [property: JsonProperty("player_out_num")] int PlayerOutNum,
    [property: JsonProperty("player_in_id")] int PlayerInId,
    [property: JsonProperty("player_out_id")] int PlayerOutId,
    [property: JsonProperty("stoppage_time")] int StoppageTime
);
#endregion