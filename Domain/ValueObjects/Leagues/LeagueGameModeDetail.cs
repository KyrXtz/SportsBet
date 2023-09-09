namespace SportsBet.Domain.ValueObjects.Leagues
{
    public class LeagueGameModeDetail : ValueObject
    {
        public int DetailId { get; private set; }
        public string TypeId { get; private set; }
        public string Description { get; private set; }
        public string Value { get; private set; }
        
        internal LeagueGameModeDetail(int detailId, string typeId, string description, string value)
        {
            DetailId = Guard.Against.Null(detailId, nameof(detailId));
            TypeId = Guard.Against.NullOrWhiteSpace(typeId, nameof(typeId));
            Description = Guard.Against.NullOrWhiteSpace(description, nameof(description));
            Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
        }

        public static LeagueGameModeDetail Create(int detailId, string typeId, string description, string value)
        {
            return new LeagueGameModeDetail(detailId, typeId, description, value);
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
