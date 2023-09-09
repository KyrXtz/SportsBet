namespace SportsBet.Domain.ValueObjects.Competitors
{
    public class TeamBetContext : CompetitorBetContext
    {
        private TeamBetContext() { }
        
        internal TeamBetContext(int? bBTeamId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            BBCompetitorId = bBTeamId;
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
