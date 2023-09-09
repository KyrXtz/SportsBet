namespace SportsBet.Domain.ValueObjects.Players
{
    public class PlayerName : ValueObject
    {
        public string Name { get; private set; }
        
        internal PlayerName(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public static PlayerName Create(string name)
        {
            return new PlayerName(name: name);
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
