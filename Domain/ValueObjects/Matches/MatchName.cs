namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchName : ValueObject
    {
        public string Name { get; private set; }

        internal MatchName(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public static MatchName Create(string name)
        {
            return new MatchName(name);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
