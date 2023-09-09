using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace Infrastructure.Tests.EF.Matches
{
    public class MatchRepositoryTests : RepositoryTests
    {
        public MatchRepositoryTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition) : base(uniqueIdGeneratorDefinition) { }

        [Theory]
        [ClassData(typeof(CreateMatchValidSeed))]
        public async Task Create_Match_Success_Test(
            int id,
            string name,
            MatchStatus status,
            DateTime gameStart,
            int homeCompetitorId,
            int awayCompetitorId,
            int sportId,
            int scoreHome = 0,
            int scoreAway = 0
            )
        {

            // Arrange
            var match = new MatchBuilder()
                .WithId(id)
                .WithName(name)
                .WithStatus(status)
                .WithDate(gameStart)
                .WithCompetitors(homeCompetitorId, awayCompetitorId)
                .WithSportId(sportId)
                .WithScore(scoreHome, scoreAway)
                .Build();

            var matchsRepo = new EfRepository<Match>(_dbContext);

            match.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            // Act
            await matchsRepo.AddAsync(match);
            var matches = await matchsRepo.ListAsync();

            // Assert
            var createdmatch = await _dbContext.Matches.FindAsync(match.Id);
            Assert.NotNull(createdmatch);
            Assert.Equal(match, createdmatch);
            Assert.Equal(1, matches.Count);
        }

        [Theory]
        [ClassData(typeof(UpdateMatchValidSeed))]
        public async Task Update_Player_Success_Test(
            int id,
            string name,
            string updatedMatchName,
            MatchStatus status,
            DateTime gameStart,
            int homeCompetitorId,
            int awayCompetitorId,
            int sportId,
            int scoreHome = 0,
            int scoreAway = 0
            )
        {
            // Arrange
            var match = new MatchBuilder()
                .WithId(id)
                .WithName(name)
                .WithStatus(status)
                .WithDate(gameStart)
                .WithCompetitors(homeCompetitorId, awayCompetitorId)
                .WithSportId(sportId)
                .WithScore(scoreHome, scoreAway)
                .Build();

            var matchsRepo = new EfRepository<Match>(_dbContext);

            match.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            await matchsRepo.AddAsync(match);

            // Act
            match.Update(updatedMatchName, status, DateTime.Now, homeCompetitorId, awayCompetitorId);
            await matchsRepo.UpdateAsync(match);

            // Assert
            var updatedMatch = await _dbContext.Matches.FindAsync(match.Id);
            Assert.Equal(updatedMatchName, updatedMatch.Name.Name);
        }
    }
}
