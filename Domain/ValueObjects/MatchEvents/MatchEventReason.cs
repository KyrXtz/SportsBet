namespace SportsBet.Domain.ValueObjects.MatchesEvents
{
    public class MatchEventReason : ValueObject
    {
        public int? Id { get; private set; }
        public string? Value { get; private set; }

        internal MatchEventReason(int? id, string? value)
        {
            Id = id;
            Value = value;
        }

        public static MatchEventReason Create(int id, string value)
        {
            return new MatchEventReason(id, value);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Value;
        }
    }
}
