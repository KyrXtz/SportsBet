namespace SportsBet.Domain.ValueObjects.Leagues
{
    public class LeagueBetContext : ValueObject
    {
        public int? BBCompetitionId { get; private set; }
        public int? MappingAgentId { get; private set; }
        public DateTime? MappedAt { get; private set; }

        private LeagueBetContext() { }
        
        internal LeagueBetContext(int? bBCompetitionId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            BBCompetitionId = bBCompetitionId;
            MappingAgentId = mappingAgentId;
            MappedAt = mappedAt;
        }

        public static LeagueBetContext Create(int? bBCompetitionId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            return new LeagueBetContext(bBCompetitionId: bBCompetitionId,
                mappingAgentId: mappingAgentId,
                mappedAt: mappedAt);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BBCompetitionId;
            yield return MappingAgentId;
        }
    }
}
