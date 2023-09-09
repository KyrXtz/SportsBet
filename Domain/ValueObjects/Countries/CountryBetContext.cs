namespace SportsBet.Domain.ValueObjects.Countries
{
    public class CountryBetContext : ValueObject
    {
        public int? BBRegionId { get; private set; }
        public int? MappingAgentId { get; private set; }
        public DateTime? MappedAt { get; private set; }

        private CountryBetContext() { }
        
        internal CountryBetContext(int? bBRegionId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            BBRegionId = bBRegionId;
            MappingAgentId = mappingAgentId;
            MappedAt = mappedAt;
        }

        public static CountryBetContext Create(int? bBRegionId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            return new CountryBetContext(bBRegionId: bBRegionId,
                mappingAgentId: mappingAgentId,
                mappedAt: mappedAt);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BBRegionId;
            yield return MappingAgentId;
        }
    }
}
