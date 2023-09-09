namespace SportsBet.Domain.ValueObjects.MatchesEvents
{
    public class SpecialEventProperty : ValueObject
    {
        public string Key { get; set; }
        public string Value { get; set; }
        private SpecialEventProperty() { }

        internal SpecialEventProperty(string key, string value)
        {
            Key = Guard.Against.NullOrWhiteSpace(key, nameof(key));
            Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
        }

        public static SpecialEventProperty Create(string key, string value)
        {
            return new SpecialEventProperty(key, value);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Key;
            yield return Value;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
