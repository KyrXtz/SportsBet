namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchStatValue : ValueObject
    {
        public int EventId { get; private set; }
        public string Value { get; private set; }

        internal MatchStatValue(int eventId,
            string value)
        {
            EventId = Guard.Against.Null(eventId, nameof(eventId));
            Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
        }

        public static MatchStatValue Create(int eventId, string value)
        {
            return new MatchStatValue(eventId: eventId,
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
