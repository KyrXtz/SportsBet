namespace SportsBet.Application.Commands.MatchesEvents;

[ProtoContract]
public class MatchsEventsCommand : Webhook
{
    [ProtoMember(1)]
    public MatchsEventsPayload Payload { get; private set; }
    private MatchsEventsCommand() { }
    public MatchsEventsCommand(MatchsEventsPayload payload)
    {
        Payload = payload;
    }
}

#region Payload Records
public record MatchsEventsPayload(MatchsEventList EventList)
{
    public MatchsEventsPayload() : this(new MatchsEventList(new List<MatchEventListItem>(),
        DateTime.UtcNow, default))
    {
    }
}

public record MatchsEventList(
    IReadOnlyList<MatchEventListItem> Events,
    DateTime DateGenerated,
    int PusherId
)
{
    public MatchsEventList() : this(new List<MatchEventListItem>(), DateTime.UtcNow, default)
    {
    }
}

public record MatchEventListItem(
    int MatchId,
    int Matchid, 
    int Minute,
    int EventNumber,
    int EventCodeId,
    DateTime Date,
    string EventCode,
    int MatchStateId,
    string MatchState,
    int ScoreHome,
    int ScoreAway,
    int Seconds,
    long CurrentPlaytime,
    bool ClockRunning,
    Dictionary<int, int> ScoreDict, //check if value should be string
    Dictionary<int, string> ValueEventDataDict,
    Dictionary<int, string> StatisticsDict,
    int CompetitorId,
    IReadOnlyList<int> RelatedEventsIds,
    IReadOnlyList<string> RelatedEventCodes, 
    IReadOnlyList<int> ClearsEventsIds,
    IReadOnlyList<string> CancelEventCodeIds,
    IReadOnlyList<int> CancelMinutes,
    IReadOnlyList<int> CancelGameTimes,
    long Timestamp,
    int? PlayerId,
    int PlayerNum,
    string PlayerName,
    string EventReason,
    int EventReasonId,
    IReadOnlyList<MatchEventLineupItem> Lineups,
    string Message,
    int MessageId,
    int AttendanceId,
    string Attendance,
    int PitchConditionId,
    string PitchCondition,
    int WeatherConditionId,
    string WeatherCondition,
    string Zone,
    int PlayerInNum,
    int PlayerOutNum,
    int PlayerInId,
    int PlayerOutId,
    int StoppageTime
)
{
    public MatchEventListItem() : this(default, default, default, default, default, default, string.Empty,
        default, string.Empty,
        default, default, default, default, default, new Dictionary<int, int>(), new Dictionary<int, string>(),
        new Dictionary<int, string>(), default, new List<int>(), new List<string>(), new List<int>(),
        new List<string>(), new List<int>(), new List<int>(), default, default, default, string.Empty, string.Empty,
        default,
        new List<MatchEventLineupItem>(), string.Empty, default, default, string.Empty, default, string.Empty,
        default, string.Empty, string.Empty, default,
        default, default, default, default)
    {
    }
}

public record MatchEventLineupItem(
    string SquadType,
    int SquadTypeId,
    string CompetitorName,
    int CompetitorId,
    IReadOnlyList<MatchEventLineupPlayerItem> LineupPlayers
)
{
    public MatchEventLineupItem() : this(string.Empty, default, string.Empty, default,
        new List<MatchEventLineupPlayerItem>())
    {
    }
}

public record MatchEventLineupPlayerItem(int JerseyNumber, string PlayerName, int PlayerId)
{
    public MatchEventLineupPlayerItem() : this(default, string.Empty, default)
    {
    }
}
#endregion