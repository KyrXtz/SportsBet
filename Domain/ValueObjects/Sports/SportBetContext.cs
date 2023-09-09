namespace SportsBet.Domain.ValueObjects.Sports
{
    public class SportBetContext : ValueObject
    {
        public int? BBCompetitionContextId { get; private set; }
        public int? MappingAgentId { get; private set; }
        public DateTime? MappedAt { get; private set; }

        private SportBetContext() { }
        
        internal SportBetContext(int? bBCompetitionContextId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            BBCompetitionContextId = bBCompetitionContextId;
            MappingAgentId = mappingAgentId;
            MappedAt = mappedAt;
        }

        public static SportBetContext Create(int? bBCompetitionContextId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            return new SportBetContext(bBCompetitionContextId: bBCompetitionContextId,
                mappingAgentId: mappingAgentId,
                mappedAt: mappedAt);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BBCompetitionContextId;
            yield return MappingAgentId;
        }
    }
}
