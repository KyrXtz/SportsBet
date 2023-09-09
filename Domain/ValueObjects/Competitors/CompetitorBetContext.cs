namespace SportsBet.Domain.ValueObjects.Competitors
{
    public class CompetitorBetContext : ValueObject
    {
        public int? BBCompetitorId { get; protected set; }
        public int? MappingAgentId { get; protected set; }
        public DateTime? MappedAt { get; protected set; }

        protected CompetitorBetContext() { }

        public static CompetitorBetContext Create(int? bBCompetitorId,
            bool isIndividual,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            return isIndividual switch
            {
                true => CreateIndividualBetContext(bBIndividualId: bBCompetitorId, mappingAgentId: mappingAgentId,
                    mappedAt: mappedAt),
                false => CreateTeamBetContext(bBTeamId: bBCompetitorId, mappingAgentId: mappingAgentId,
                    mappedAt: mappedAt)
            };
        }
        private static TeamBetContext CreateTeamBetContext(int? bBTeamId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            return new TeamBetContext(bBTeamId: bBTeamId,
                mappingAgentId: mappingAgentId,
                mappedAt: mappedAt);
        }

        private static IndividualBetContext CreateIndividualBetContext(int? bBIndividualId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            return new IndividualBetContext(bBIndividualId: bBIndividualId,
                mappingAgentId: mappingAgentId,
                mappedAt: mappedAt);
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
