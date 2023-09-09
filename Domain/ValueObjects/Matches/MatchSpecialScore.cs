namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchSpecialScore : ValueObject
    {
        public int EventId { get; private set; }
        public int Value { get; private set; }

        internal MatchSpecialScore(int eventId,
            int value)
        {
            EventId = Guard.Against.Null(eventId, nameof(eventId));
            Value = Guard.Against.Null(value, nameof(value));
        }

        public static MatchSpecialScore Create(int eventId, int value)
        {
            return new MatchSpecialScore(eventId: eventId,
                value: value);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EventId;
            yield return Value;
        }
    }
}
