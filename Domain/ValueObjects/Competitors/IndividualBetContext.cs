namespace SportsBet.Domain.ValueObjects.Competitors
{
    public class IndividualBetContext : CompetitorBetContext
    {
        private IndividualBetContext() { }
        
        internal IndividualBetContext(int? bBIndividualId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            BBCompetitorId = bBIndividualId;
            MappingAgentId = mappingAgentId;
            MappedAt = mappedAt;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BBCompetitorId;
            yield return MappingAgentId;
        }
    }
}
