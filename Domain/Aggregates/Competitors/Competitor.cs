namespace SportsBet.Domain.Aggregates.Competitors
{
    public class Competitor : BaseEntity<int>, IAggregateRoot
    {
        public CompetitorName CompetitorName { get; private set; }
        public CompetitorBetContext BetContext { get; private set; }
        public bool IsIndividual { get; private set; }
        public int SportId { get; private set; }
        public long CountryId { get; private set; }


        private Competitor() { }

        internal Competitor(int id,
            CompetitorName name,
            bool isIndividual,
            int sportId,
            long countryId)
        {
            Id = Guard.Against.InvalidInput(id, nameof(id), id => id > 0);
            CompetitorName = name;
            IsIndividual = isIndividual;
            SportId = Guard.Against.InvalidInput(sportId, nameof(sportId), sportId => sportId > 0 );
            CountryId = Guard.Against.InvalidInput(countryId, nameof(countryId), countryId => countryId > 0);

            _domainEvents.Add(new CompetitorAddedEvent(this));
        }

        public static Competitor Create(int id,
            string name,
            bool isIndividual,
            int sportId,
            long countryId)
        {
            var competitorName = CompetitorName.Create(name: name);

            var competitor = new Competitor(id: id,
                name: competitorName,
                isIndividual: isIndividual,
                sportId: sportId,
                countryId: countryId);

            return competitor;
        }

        public void Update(string name)
        {
            var competitorName = CompetitorName.Create(name: name);

            CompetitorName = competitorName;

            _domainEvents.Add(new CompetitorUpdatedEvent(this));
        }
        public void UpdateCompetitorName(CompetitorName competitorName)
        {
            CompetitorName = competitorName;

            _domainEvents.Add(new CompetitorUpdatedEvent(this));
        }
        public void Map(int bBCompetitorId, int mappingAgentId)
        {
            var competitorBetContext = CompetitorBetContext.Create(bBCompetitorId: bBCompetitorId,
                isIndividual: IsIndividual,
                mappingAgentId: mappingAgentId,
                mappedAt: DateTime.UtcNow);

            BetContext = competitorBetContext;

            _domainEvents.Add(new CompetitorMappedEvent(this));
        }

        public void Unmap()
        {
            var competitorBetContext = CompetitorBetContext.Create(bBCompetitorId: null,
                IsIndividual,
                mappingAgentId: null,
                mappedAt: null);

            BetContext = competitorBetContext;

            _domainEvents.Add(new CompetitorUnmappedEvent(this));
        }
        public bool IsMapped()
        {
            return BetContext != null && BetContext.BBCompetitorId != default;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    }
}