namespace Infrastructure.Tests.EF.Series
{
    public class SeriesRepositoryTests : RepositoryTests
    {
        public SeriesRepositoryTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition) : base(uniqueIdGeneratorDefinition) { }

        [Theory]
        [ClassData(typeof(CreateSeriesValidSeed))]
        public async Task Create_Series_Success_Test(
            int id,
            int numberOfMatches,
            int teamOneId,
            int teamOneScore,
            int teamOneStanding,
            int teamTwoId,
            int teamTwoScore,
            int teamTwoStanding,
            int winnerTeamId
            )
        {
            // Arrange
            var series = new SeriesBuilder()
                .WithId(id)
                .WithSeriesInfo(numberOfMatches)
                .WithSeriesTeamOne(teamOneId)
                .WithSeriesScoreOne(teamOneScore, teamOneStanding)
                .WithSeriesTeamTwo(teamTwoId)
                .WithSeriesScoreTwo(teamTwoScore, teamTwoStanding)
                .WithWinnerTeamId(winnerTeamId)
                .Build();

            var seriesRepo = new EfRepository<SportsBet.Domain.Aggregates.Series.Series>(_dbContext);

            series.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            // Act
            await seriesRepo.AddAsync(series);
            var seriesL = await seriesRepo.ListAsync();

            // Assert
            var createdSeries = await _dbContext.Series.FindAsync(series.Id);
            Assert.NotNull(createdSeries);
            Assert.Equal(series, createdSeries);
            Assert.Equal(1, seriesL.Count);
        }

        [Theory]
        [ClassData(typeof(UpdateSeriesValidSeed))]
        public async Task Update_Series_Success_Test(
            int id,
            int numberOfMatches,
            int teamOneId,
            int teamOneScore,
            int teamOneStanding,
            int teamTwoId,
            int teamTwoScore,
            int teamTwoStanding,
            int winnerTeamId,
            int updatedTeamOneScore,
            int updatedTteamOneStanding,
            int updatedTeamOneId,
            int updatedTeamTwoScore,
            int updatedTeamTwoStanding,
            int updatedTeamTwoId
            )
        {
            // Arrange
            var series = new SeriesBuilder()
                .WithId(id)
                .WithSeriesInfo(numberOfMatches)
                .WithSeriesTeamOne(teamOneId)
                .WithSeriesScoreOne(teamOneScore, teamOneStanding)
                .WithSeriesTeamTwo(teamTwoId)
                .WithSeriesScoreTwo(teamTwoScore, teamTwoStanding)
                .WithWinnerTeamId(winnerTeamId)
                .Build();

            var seriesRepo = new EfRepository<SportsBet.Domain.Aggregates.Series.Series>(_dbContext);

            series.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            await seriesRepo.AddAsync(series);

            var updatedSeriesOneScore = SeriesScore.Create(updatedTeamOneScore, updatedTteamOneStanding);
            var updatedSeriesTeamOne = SeriesTeam.Create(updatedTeamOneId, updatedSeriesOneScore);

            var updatedSeriesTwoScore = SeriesScore.Create(updatedTeamTwoScore, updatedTeamTwoStanding);
            var updatedSeriesTeamTwo = SeriesTeam.Create(updatedTeamTwoId, updatedSeriesTwoScore);

            //Act
            series.Update(updatedSeriesTeamOne, updatedSeriesTeamTwo, winnerTeamId);
            await seriesRepo.UpdateAsync(series);

            // Assert
            var updatedSeries = await _dbContext.Series.FindAsync(series.Id); 
            Assert.Equal(updatedTeamOneScore, updatedSeries.Team1.Score.Score);
            Assert.Equal(updatedTteamOneStanding, updatedSeries.Team1.Score.Standing);
            Assert.Equal(updatedTeamTwoScore, updatedSeries.Team2.Score.Score);
            Assert.Equal(updatedTeamTwoStanding, updatedSeries.Team2.Score.Standing);
        }
    }
}
