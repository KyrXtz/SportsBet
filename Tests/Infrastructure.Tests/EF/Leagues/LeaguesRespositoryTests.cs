namespace Infrastructure.Tests.EF.Leagues
{
    public class LeaguesRespositoryTests : RepositoryTests
    {
        public LeaguesRespositoryTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition) : base(uniqueIdGeneratorDefinition) { }

        [Theory]
        [ClassData(typeof(CreateLeagueValidSeed))]
        public async Task Create_League_Success_Test(
            int id,
            string name,
            long countryId,
            int sportId
            )
        {
            // Arrange
            var league = new LeagueBuilder()
                .WithId(id)
                .WithName(name)
                .WithCountryId(countryId)
                .WithSportId(sportId)
                .Build();

            var leaguesRepo = new EfRepository<League>(_dbContext);

            league.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            // Act
            await leaguesRepo.AddAsync(league);
            var leagues = await leaguesRepo.ListAsync();

            // Assert
            var createdLeague = await _dbContext.Leagues.FindAsync(league.Id);
            Assert.NotNull(createdLeague);
            Assert.Equal(league, createdLeague);
            Assert.Equal(1, leagues.Count);
        }

        [Theory]
        [ClassData(typeof(UpdateLeagueValidSeed))]
        public async Task Update_Country_Success_Test(string leagueName, string updatedLeagueName)
        {
            // Arrange
            var league = new LeagueBuilder()
                .WithName(leagueName)
                .Build();

            var leaguesRepo = new EfRepository<League>(_dbContext);

            league.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            await leaguesRepo.AddAsync(league);

            // Act
            league.Update(updatedLeagueName);
            await leaguesRepo.UpdateAsync(league);

            // Assert
            var updatedLeague = await _dbContext.Leagues.FindAsync(league.Id);
            Assert.Equal(updatedLeagueName, updatedLeague.Name.Name);
        }
    }
}
