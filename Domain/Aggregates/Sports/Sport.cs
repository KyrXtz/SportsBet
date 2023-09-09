namespace SportsBet.Domain.Aggregates.Sports
{
    public class Sport : BaseEntity<int>, IAggregateRoot
    {
        public SportName Name { get; private set; }
        public SportBetContext BetContext { get; private set; }

        private Sport() { }

        internal Sport(int id, SportName sportName)
        {
            Id = Guard.Against.InvalidInput(id, nameof(id), id => id >= 0 );
            Name = sportName;

            _domainEvents.Add(new SportAddedEvent(this));
        }

        public static Sport Create(int id, string name)
        {
            var sportName = SportName.Create(name);

            var sport = new Sport(id: id, sportName: sportName);

            return sport;
        }

        public void Update(string name)
        {
            var sportName = SportName.Create(name: name);

            Name = sportName;

            _domainEvents.Add(new SportUpdatedEvent(this));
        }

        public void UpdateSportName(SportName sportName)
        {
            Name = sportName;

            _domainEvents.Add(new SportUpdatedEvent(this));
        }

        public void Map(int bBCompetitionContextId, int mappingAgentId)
        {
            var sportBetContext = SportBetContext.Create(bBCompetitionContextId: bBCompetitionContextId,
                mappingAgentId: mappingAgentId,
                mappedAt: DateTime.UtcNow);

            BetContext = sportBetContext;

            _domainEvents.Add(new SportMappedEvent(this));
        }

        public void Unmap()
        {
            var sportBetContext = SportBetContext.Create(bBCompetitionContextId: null,
                mappingAgentId: null,
                mappedAt: null);

            BetContext = sportBetContext;

            _domainEvents.Add(new SportUnmappedEvent(this));
        }
        
        public bool IsMapped()
        {
            return BetContext != null && BetContext.BBCompetitionContextId != default;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
