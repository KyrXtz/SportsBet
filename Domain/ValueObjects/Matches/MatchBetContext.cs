namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchBetContext : ValueObject
    {
        public int? BBEventHistoryId { get; private set; }
        public int? MappingAgentId { get; private set; }
        public DateTime? MappedAt { get; private set; }

        private MatchBetContext() { }
        
        internal MatchBetContext(int? bBEventHistoryId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            BBEventHistoryId = bBEventHistoryId;
            MappingAgentId = mappingAgentId;
            MappedAt = mappedAt;
        }

        public static MatchBetContext Create(int? bBEventHistoryId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            return new MatchBetContext(bBEventHistoryId: bBEventHistoryId,
                mappingAgentId: mappingAgentId,
                mappedAt: mappedAt);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BBEventHistoryId;
            yield return MappingAgentId;
        }
    }
}
