namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchDetail : ValueObject
    {
        public int DetailId { get; private set; }
        public string TypeId { get; private set; }
        public string Description { get; private set; }
        public string Value { get; private set; }
        
        internal MatchDetail(int detailId, string typeId, string description, string value)
        {
            DetailId = Guard.Against.Null(detailId, nameof(detailId));
            TypeId = Guard.Against.NullOrWhiteSpace(typeId, nameof(typeId));
            Description = Guard.Against.NullOrWhiteSpace(description, nameof(description));
            Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
        }

        public static MatchDetail Create(int detailId, string typeId, string description, string value)
        {
            return new MatchDetail(detailId, typeId, description, value);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DetailId;
            yield return TypeId;
            yield return Description;
            yield return Value;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
