namespace SportsBet.Domain.ValueObjects.Countries
{
    public class CountryName : ValueObject
    {
        public string ISOCode { get; private set; }
        public string Name { get; private set; }

        private CountryName() { }

        internal CountryName(string code, string name)
        {
            ISOCode = code;
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public static CountryName Create(string code, string name)
        {
            return new CountryName(code, name);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ISOCode;
            yield return Name;
        }
    }
}
