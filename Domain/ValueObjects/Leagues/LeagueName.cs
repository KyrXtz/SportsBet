namespace SportsBet.Domain.ValueObjects.Leagues
{
    public class LeagueName : ValueObject
    {
        public string Name { get; private set; }

        internal LeagueName(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public static LeagueName Create(string name)
        {
            return new LeagueName(name);
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
