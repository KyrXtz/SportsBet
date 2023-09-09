namespace TestDefinitions.Builders.Leagues
{
    public class LeagueBuilder
    {
        private LeagueBetContext leagueBetContext = new LeagueBetContext(1, 1, DateTime.Now);
        private int id = 1;
        private long countryId = 1;
        private int sportId = 1;
        private string name = "leagueName";
        private string regularPlaytime = "regularPlaytime";
        private string overPlaytime = "overPlaytime";
        private bool hasPenaltyShootout = false;
        private bool hasPlayerData = false;
        private int detailId = 1;
        private string typeId = "typeId";
        private string description = "description";
        private string value = "value";
        private int bBLeagueId = 1;
        private int mappingAgentId = 1;
        private LeagueGameModeDetail leagueGameModeDetail;
        public League Build()
        {
            var league = League.Create(id, name, countryId, sportId);
            league.Map(bBLeagueId, mappingAgentId);
            league.AddGameModeDetails(leagueGameModeDetail);
            return league;
        }

        public LeagueBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }
        public LeagueBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public LeagueBuilder WithCountryId(long countryId)
        {
            this.countryId = countryId;
            return this;
        }
        public LeagueBuilder WithSportId(int sportId)
        {
            this.sportId = sportId;
            return this;
        }
        public LeagueBuilder WithLeagueParameters(
            string regularPlaytime,
            string overPlaytime,
            bool hasPenaltyShootout,
            bool hasPlayerData
            )
        {
            this.regularPlaytime = regularPlaytime;
            this.overPlaytime = overPlaytime;
            this.hasPenaltyShootout = hasPenaltyShootout;
            this.hasPlayerData = hasPlayerData;
            return this;
        }
        public LeagueBuilder WithLeagueGameModeDetail(
            int detailId,
            string typeId,
            string description,
            string value
            )
        {
            this.leagueGameModeDetail = LeagueGameModeDetail.Create(detailId, typeId, description, value);
            return this;
        }
        public LeagueBuilder WithBetContext(int bBLeagueId, int mappingAgentId)
        {
            this.bBLeagueId = bBLeagueId;
            this.mappingAgentId = mappingAgentId;
            return this;
        }

        public static implicit operator League(LeagueBuilder instance)
        {
            return instance.Build();
        }
    }
}
