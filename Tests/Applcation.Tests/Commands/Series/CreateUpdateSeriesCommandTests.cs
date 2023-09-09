namespace Application.Tests.Commands.Series
{
    [Collection("UniqueId Generator")]
    public class CreateUpdateSeriesCommandTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public CreateUpdateSeriesCommandTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {

        }

        [Theory]
        [ClassData(typeof(CreateUpdateSeriesCommandValidSeed))]
        private async Task CreateUpdateCommand_ValidParameters(
            SeriesItem seriesItem,
            int numberOfMatches,
            int teamOneId,
            int teamOneScore,
            int teamOneStanding,
            int teamTwoId,
            int teamTwoScore,
            int teamTwoStanding,
            int winnerTeamId,
            int leg,
            int matchId,
            int listAsyncTimesCalledFromSeed,
            int addRangeAsyncTimesCalledFromSeed,
            int updateRangeAsyncTimesCalledFromSeed
            )
        {
            var existingSingularSeries = new SeriesBuilder()
                .Build();

            if (leg > 0 && matchId > 0)
            {
                existingSingularSeries = new SeriesBuilder()
                .WithSeriesInfo(numberOfMatches)
                .WithSeriesTeamOne(teamOneId)
                .WithSeriesScoreOne(teamOneScore, teamOneStanding)
                .WithSeriesTeamTwo(teamTwoId)
                .WithSeriesScoreTwo(teamTwoScore, teamTwoStanding)
                .WithWinnerTeamId(winnerTeamId)
                .WithSeriesMatch(leg, matchId)
                .Build();
            }
            else
            {
                existingSingularSeries = new SeriesBuilder()
                .WithSeriesInfo(numberOfMatches)
                .WithSeriesTeamOne(teamOneId)
                .WithSeriesScoreOne(teamOneScore, teamOneStanding)
                .WithSeriesTeamTwo(teamTwoId)
                .WithSeriesScoreTwo(teamTwoScore, teamTwoStanding)
                .WithWinnerTeamId(winnerTeamId)
                .Build();
            }
                

            var existingSeries = new List<SportsBet.Domain.Aggregates.Series.Series>() { existingSingularSeries };
            var seriesItems = new List<SeriesItem>() { seriesItem };

            var mockRepo = new MockRepository<SportsBet.Domain.Aggregates.Series.Series>(existingSeries);
            var mockCommand = new MockCommand
                <SportsBet.Domain.Aggregates.Series.Series,
                CreateUpdateSeriesCommand,
                CreateUpdateSeriesCommandHandler,
                Result<List<long>>,
                SeriesItem>
                (seriesItems, mockRepo._repository);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(
                listAsyncTimesCalled: listAsyncTimesCalledFromSeed,
                addRangeAsyncTimesCalled: addRangeAsyncTimesCalledFromSeed,
                updateRangeAsyncTimesCalled: updateRangeAsyncTimesCalledFromSeed)
                );
        }
    }
}
