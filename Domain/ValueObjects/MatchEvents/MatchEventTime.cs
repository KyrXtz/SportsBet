namespace SportsBet.Domain.ValueObjects.MatchesEvents;
public class MatchEventTime : ValueObject
{
    public int Minute { get; private set; }
    public long? Timestamp { get; private set; }
    public bool? ClockRunning { get; private set; }
    public DateTime Date { get; private set; }

    internal MatchEventTime(int minute, long? timestamp, DateTime date, bool? clockRunning)
    {
        Minute = Guard.Against.Null(minute, nameof(minute));
        Timestamp = Guard.Against.Null(timestamp, nameof(timestamp));
        ClockRunning = clockRunning;
        Date = Guard.Against.Null(date, nameof(date));
    }

    public static MatchEventTime Create(int minute, long? timestamp, DateTime date, bool? clockRunning = null)
    {
        return new MatchEventTime(minute, timestamp, date, clockRunning);
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Minute;
        yield return Timestamp;
        yield return ClockRunning;
        yield return Date;
    }
}