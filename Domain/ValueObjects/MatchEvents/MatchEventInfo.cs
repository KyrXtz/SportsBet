namespace SportsBet.Domain.ValueObjects.MatchesEvents
{
    public class MatchEventInfo : ValueObject
    {
        public int EventId { get; private set; }
        public int EventNumber { get; private set; }
        public string EventCode { get; private set; }
        public MatchState State { get; private set; }

        internal MatchEventInfo(int eventId, int eventNumber, string eventCode, MatchState state)
        {
            EventId = Guard.Against.Null(eventId, nameof(eventId));
            EventNumber = Guard.Against.Null(eventNumber, nameof(eventNumber));
            EventCode = Guard.Against.NullOrWhiteSpace(eventCode, nameof(eventCode));
            State = Guard.Against.Null(state, nameof(state));
        }

        public static MatchEventInfo Create(int eventId, int eventNumber, string eventCode, MatchState state)
        {
            return new MatchEventInfo(eventId, eventNumber, eventCode, state);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EventId;
            yield return EventNumber;
            yield return EventCode;
            yield return State;
        }
    }
}
