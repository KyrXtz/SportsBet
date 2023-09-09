namespace Domain.Tests.Aggregates.Leagues
{
    public class LeagueTests
    {
        [Theory]
        [ClassData(typeof(LeagueValidSeed))]
        public void Create_ValidParameters(
            int id,
            string name,
            long countryId,
            int sportId
            )
        {
            var league = new LeagueBuilder()
                .WithId(id)
                .WithName(name)
                .WithCountryId(countryId)
                .WithSportId(sportId)
                .Build();

            Assert.NotNull(league);
            Assert.Equal(id, league.Id);
            Assert.Equal(name, league.Name.Name);
            Assert.Equal(countryId, league.CountryId);
            Assert.Equal(sportId, league.SportId);
        }

        [Theory]
        [ClassData(typeof(LeagueInvalidSeed))]
        public void Create_InvalidParameters(
            int id,
            string name,
            long countryId,
            int sportId
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var league = new LeagueBuilder()
                .WithId(id)
                .WithName(name)
                .WithCountryId(countryId)
                .WithSportId(sportId)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateLeagueValidSeed))]
        public void UpdateLeague_ValidParameters(string name)
        {
            //Arrange
            var league = new LeagueBuilder()
                .Build();

            //Act
            league.Update(name);

            //Assert
            Assert.Equal(name, league.Name.Name);
        }

        [Theory]
        [ClassData(typeof(UpdateLeagueInValidSeed))]
        public void UpdateLeague_InvalidParameters(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var league = new LeagueBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateLeagueNameValidSeed))]
        public void UpdateLeagueName_ValidParameters(string name)
        {
            //Arrange
            var league = new LeagueBuilder()
                .Build();

            var leagueName = LeagueName.Create(name);

            //Act
            league.UpdateLeagueName(leagueName);

            //Assert
            Assert.Equal(name, leagueName.Name);
        }

        [Theory]
        [ClassData(typeof(UpdateLeagueNameInValidSeed))]
        public void UpdateLeagueName_InvalidParameters(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var league = new LeagueBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateLeagueParametersValidSeed))] 
        public void UpdateLeagueParameters_ValidParameters(
            string regularPlaytime,
            string overPlaytime,
            bool hasPenaltyShootout,
            bool hasPlayerData
            )
        {
            //Arrange
            var league = new LeagueBuilder()
                .WithLeagueParameters(regularPlaytime, overPlaytime, hasPenaltyShootout, hasPlayerData)
                .Build();

            var leagueParameters = LeagueParameters.Create(
                regularPlaytime,
                overPlaytime,
                hasPenaltyShootout,
                hasPlayerData
                );

            //Act
            league.UpdateLeagueParameters(leagueParameters);

            //Assert
            Assert.Equal(leagueParameters, league.Parameters);
        }

        [Theory]
        [ClassData(typeof(AddLeagueParametersValidSeed))]
        public void AddLeagueParameters_ValidParameters(
            string regularPlaytime,
            string overPlaytime,
            bool hasPenaltyShootout,
            bool hasPlayerData
            )
        {
            //Arrange
            var league = new LeagueBuilder()
                .WithLeagueParameters(regularPlaytime, overPlaytime, hasPenaltyShootout, hasPlayerData)
                .Build();

            //Act
            league.AddLeagueParameters(regularPlaytime, overPlaytime, hasPenaltyShootout, hasPlayerData);

            //Assert
            Assert.Equal(regularPlaytime, league.Parameters.RegularPlaytime);
            Assert.Equal(overPlaytime, league.Parameters.OverPlaytime);
            Assert.Equal(hasPenaltyShootout, league.Parameters.HasPenaltyShootout);
            Assert.Equal(hasPlayerData, league.Parameters.HasPlayerData);
        }

        [Theory]
        [ClassData(typeof(AddGameModeDetailsValidSeed))]
        public void AddGameModeDetail_ValidParameters(
            int detailId,
            string typeId,
            string description,
            string value
            )
        {
            //Arrange
            var league = new LeagueBuilder()
                .WithLeagueGameModeDetail(detailId, typeId, description, value)
                .Build();

            var leagueGameModeDetail = LeagueGameModeDetail.Create(
                detailId,
                typeId,
                description,
                value
                );

            //Act
            league.AddGameModeDetails(leagueGameModeDetail);

            //Assert
            Assert.Equal(detailId, league.LeagueGameModeDetails.ToList()[0].DetailId);
            Assert.Equal(typeId, league.LeagueGameModeDetails.ToList()[0].TypeId);
            Assert.Equal(description, league.LeagueGameModeDetails.ToList()[0].Description);
            Assert.Equal(value, league.LeagueGameModeDetails.ToList()[0].Value);
        }

        [Theory]
        [ClassData(typeof(AddGameModeDetailsInValidSeed))]
        public void AddGameModeDetail_InvalidParameters(
            int detailId,
            string typeId,
            string description,
            string value
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var league = new LeagueBuilder()
                .WithLeagueGameModeDetail(detailId, typeId, description, value)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(AddGameModeDetailsValidSeed))]
        public void AddGameModeDetails_ValidParameters(
            int detailId,
            string typeId,
            string description,
            string value
            )
        {
            //Arrange
            var league = new LeagueBuilder()
                .WithLeagueGameModeDetail(detailId, typeId, description, value)
                .Build();

            var leagueGameModeDetails = new List<LeagueGameModeDetail>();

            var leagueGameModeDetail = LeagueGameModeDetail.Create(
                detailId,
                typeId,
                description,
                value
                );

            leagueGameModeDetails.Add(leagueGameModeDetail);

            //Act
            league.AddGameModeDetails(leagueGameModeDetails);

            //Assert

            foreach (var gameModeDetail in leagueGameModeDetails)
            {
                Assert.Equal(detailId, gameModeDetail.DetailId);
                Assert.Equal(typeId, gameModeDetail.TypeId);
                Assert.Equal(description, gameModeDetail.Description);
                Assert.Equal(value, gameModeDetail.Value);
            }
        }

        [Theory]
        [ClassData(typeof(AddGameModeDetailsInValidSeed))]
        public void AddGameModeDetails_InvalidParameters(
            int detailId,
            string typeId,
            string description,
            string value
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var league = new LeagueBuilder()
                .WithLeagueGameModeDetail(detailId, typeId, description, value)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(MapLeagueValidSeed))]
        public void MapLeague_ValidParameters(int oldBBLeagueId, int oldMappingAgentId, int newBBLeagueId, int newMappingAgentId)
        {
            //Arrange
            var league = new LeagueBuilder()
                .WithBetContext(oldBBLeagueId, oldMappingAgentId)
                .Build();

            //Act
            league.Map(newBBLeagueId, newMappingAgentId);

            //Assert
            Assert.Equal(newBBLeagueId, league.BetContext.BBCompetitionId);
            Assert.Equal(newMappingAgentId, league.BetContext.MappingAgentId);
        }

        [Theory]
        [ClassData(typeof(UnMapLeagueValidSeed))]
        public void UnMapLeague_ValidParameters(int bBLeagueId, int mappingAgentId)
        {
            //Arrange
            var league = new LeagueBuilder()
                .WithBetContext(bBLeagueId, mappingAgentId)
                .Build();

            //Act
            league.Unmap();

            //Assert
            Assert.Null(league.BetContext.BBCompetitionId);
            Assert.Null(league.BetContext.MappingAgentId);
        }
    }
}
