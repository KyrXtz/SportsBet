namespace SportsBet.Domain.ValueObjects.Sports
{
    public class SportName : ValueObject
    {
        public string Name { get; private set; }

        internal SportName(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public static SportName Create(string name)
        {
            return new SportName(name);
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
