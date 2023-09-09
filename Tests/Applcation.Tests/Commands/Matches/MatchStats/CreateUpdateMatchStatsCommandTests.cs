namespace Application.Tests.Commands.Matches.MatchsStats
{
    [Collection("UniqueId Generator")]
    public class CreateUpdateMatchsStatsCommandTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public CreateUpdateMatchsStatsCommandTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {

        }

        [Theory]
        [ClassData(typeof(CreateUpdateMatchsStatsCommandValidSeed))]
        private async Task CreateUpdateCommand_ValidParameters(
            int existingmatchId,
            string existingmatchName,
            MatchStatus existingmatchStatus,
            DateTime existingmatchGameStart,
            int existingmatchHomeCompetitorId,
            int existingmatchAwayCompetitorId,
            int existingmatchSportId,
            int existingmatchScoreHome,
            int existingmatchScoreAway,
            MatchStatItem matchStatItem,
            int listAsyncTimesCalledFromSeed,
            int addRangeAsyncTimesCalledFromSeed,
            int updateRangeAsyncTimesCalledFromSeed
            )
        {
            var existingMatch = new MatchBuilder()
                .WithId(existingmatchId)
                .WithName(existingmatchName)
                .WithStatus(existingmatchStatus)
                .WithDate(existingmatchGameStart)
                .WithCompetitors(existingmatchHomeCompetitorId, existingmatchAwayCompetitorId)
                .WithSportId(existingmatchSportId)
                .WithScore(existingmatchScoreHome, existingmatchScoreAway)
                .Build();

            var existingMatchs = new List<Match>() { existingMatch };
            var matchStatItems = new List<MatchStatItem>() { matchStatItem };

            var mockRepo = new MockRepository<Match>(existingMatchs);
            var mockCommand = new MockCommand
                <Match, CreateUpdateMatchsStatsCommand, CreateUpdateMatchsStatsCommandHandler, Result<List<int>>, MatchStatItem>
                (matchStatItems, mockRepo._repository);

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
