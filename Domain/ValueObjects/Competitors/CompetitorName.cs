namespace SportsBet.Domain.ValueObjects.Competitors
{
    public class CompetitorName : ValueObject
    {
        public string Name { get; private set; }
        
        internal CompetitorName(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public static CompetitorName Create(string name)
        {
            return new CompetitorName(name);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
