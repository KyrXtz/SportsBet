namespace SportsBet.Domain.Aggregates.Leagues
{
    public class League : BaseEntity<int>, IAggregateRoot
    {
        public LeagueName Name { get; private set; }
        public LeagueBetContext BetContext { get; private set; }
        public LeagueParameters Parameters { get; private set; }

        private List<LeagueGameModeDetail> _leagueGameModeDetails = new List<LeagueGameModeDetail>();
        public IReadOnlyCollection<LeagueGameModeDetail> LeagueGameModeDetails => _leagueGameModeDetails.AsReadOnly();
        public long CountryId { get; private set; }
        public int SportId { get; private set; }

        private League() { }

        internal League(int id,
            LeagueName name,
            long countryId,
            int sportId)
        {
            Id = Guard.Against.InvalidInput(id, nameof(id), id => id > 0);
            Name = name;
            CountryId = Guard.Against.InvalidInput(countryId, nameof(countryId), countryId => countryId > 0);
            SportId = Guard.Against.InvalidInput(sportId, nameof(sportId), sportId => sportId > 0);

            _domainEvents.Add(new LeagueAddedEvent(this));
        }

        public static League Create(int id,
            string name,          
            long countryId,
            int sportId)
        {
            var leagueName = LeagueName.Create(name: name);

            var league = new League(id: id,
                name: leagueName,
                countryId: countryId,
                sportId: sportId);

            return league;
        }

        public void Update(string name)
        {
            var leagueName = LeagueName.Create(name: name);

            Name = leagueName;

            _domainEvents.Add(new LeagueUpdatedEvent(this));
        }

        public void UpdateLeagueName(LeagueName leagueName)
        {
            Name = leagueName;

            _domainEvents.Add(new LeagueUpdatedEvent(this));
        }

        public void UpdateLeagueParameters(LeagueParameters parameters)
        {
            Parameters = parameters;

            _domainEvents.Add(new LeagueUpdatedEvent(this));
        }
        public void AddLeagueParameters(string? regularPlaytime,
            string? overPlaytime,
            bool? hasPenaltyShootout,
            bool? hasPlayerData)
        {
            var leagueParameters = LeagueParameters.Create(regularPlaytime, overPlaytime, hasPenaltyShootout, hasPlayerData);

            Parameters = leagueParameters;

            _domainEvents.Add(new LeagueUpdatedEvent(this));
        }
        public void AddGameModeDetails(LeagueGameModeDetail gameModeDetail)
        {
            _leagueGameModeDetails.Add(gameModeDetail);

            _domainEvents.Add(new LeagueGameModeDetailsAddedEvent(this));
        }

        public void AddGameModeDetails(IEnumerable<LeagueGameModeDetail> gameModeDetails)
        {
            _leagueGameModeDetails.AddRange(gameModeDetails);

            _domainEvents.Add(new LeagueGameModeDetailsAddedEvent(this));
        }

        public void Map(int bBLeagueId, int mappingAgentId)
        {
            var leagueBetContext = LeagueBetContext.Create(bBCompetitionId: bBLeagueId,
                mappingAgentId: mappingAgentId,
                mappedAt: DateTime.UtcNow);

            BetContext = leagueBetContext;

            _domainEvents.Add(new LeagueMappedEvent(this));
        }

        public void Unmap()
        {
            var leagueBetContext = LeagueBetContext.Create(bBCompetitionId: null,
                mappingAgentId: null,
                mappedAt: null);

            BetContext = leagueBetContext;

            _domainEvents.Add(new LeagueUnmappedEvent(this));
        }
        public bool IsMapped()
        {
            return BetContext != null && BetContext.BBCompetitionId != default;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
