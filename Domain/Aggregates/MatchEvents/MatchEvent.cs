using SportsBet.Domain.ValueObjects.MatchesEvents;

namespace SportsBet.Domain.Aggregates.MatchEvents;
public class MatchEvent : BaseEntity<long>, IAggregateRoot
{
    public MatchEventInfo Info { get; private set; }
    public MatchEventTime Time { get; private set; }
    public MatchEventReason Reason { get; private set; }

    private List<SpecialEventProperty> _specialEvent = new List<SpecialEventProperty>();
    public IReadOnlyCollection<SpecialEventProperty> SpecialEvent => _specialEvent.AsReadOnly();
    public int[]? RelatedMatchEventNumbers { get; private set; }
    public int[]? ClearedMatchEventNumbers { get; private set; }
    public int MatchId { get; private set; }

    private MatchEvent() { }
    internal MatchEvent(MatchEventInfo info,
        MatchEventTime time,
        int matchId)
    {
        Id = UniqueIdGenerator.CreateId();
        Info = info;
        Time = time;
        MatchId = matchId;

        _domainEvents.Add(new MatchEventAddedEvent(this));
    }

    public static MatchEvent Create(int eventId,
        int eventNumber,
        string eventCode,
        MatchState state,
        int minute,
        long? timestamp,
        DateTime date,
        int matchId,
        bool? clockRunning = false)
    {
        var matchEventInfo = MatchEventInfo.Create(eventId, eventNumber, eventCode, state);
        var matchEventTime = MatchEventTime.Create(minute, timestamp, date, clockRunning);

        var matchEvent = new MatchEvent(info: matchEventInfo,
            time: matchEventTime, matchId: matchId);

        return matchEvent;
    }

    public void Update(int minute,
        long timestamp,
        DateTime date,
        MatchEventReason? reason)
    {
        var matchEventTime = MatchEventTime.Create(minute, timestamp, date, Time.ClockRunning);

        Reason = reason ?? Reason;
        Time = matchEventTime;

        _domainEvents.Add(new MatchEventUpdatedEvent(this));
    }

    public void AddRelatedMatchEventNumbers(int[] eventNumbers)
    {
        RelatedMatchEventNumbers = eventNumbers;

        _domainEvents.Add(new MatchEventUpdatedEvent(this));
    }

    public void AddClearedMatchEventNumbers(int[] eventNumbers)
    {
        ClearedMatchEventNumbers = eventNumbers;

        _domainEvents.Add(new MatchEventUpdatedEvent(this));
    }

    public void AddEventReason(MatchEventReason eventReason)
    {
        Reason = eventReason;

        _domainEvents.Add(new MatchEventUpdatedEvent(this));
    }

    public void AddSpecialEvent(Dictionary<string, string> specialEvent)
    {
        var specialEventList = new List<SpecialEventProperty>();
        specialEventList.AddRange(specialEvent?
            .Where(s => s.Value != string.Empty)
            .Select(s => SpecialEventProperty.Create(s.Key, s.Value)));

        _specialEvent = specialEventList;

        _domainEvents.Add(new MatchEventUpdatedEvent(this));
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}