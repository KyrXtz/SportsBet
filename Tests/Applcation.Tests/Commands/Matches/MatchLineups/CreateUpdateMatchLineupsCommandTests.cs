namespace Application.Tests.Commands.Matches.MatchsLineups
{
    [Collection("UniqueId Generator")]
    public class CreateUpdateMatchsLineupsCommandTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public CreateUpdateMatchsLineupsCommandTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {

        }

        [Theory]
        [ClassData(typeof(CreateUpdateMatchsLineupsCommandValidSeed))]
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
            MatchLineupItem matchLineupItem,
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
            var matchLineupItems = new List<MatchLineupItem>() { matchLineupItem };

            var mockRepo = new MockRepository<Match>(existingMatchs);
            var mockCommand = new MockCommand
                <Match, CreateUpdateMatchsLineupsCommand, CreateUpdateMatchsLineupsCommandHandler, Result<List<int>>, MatchLineupItem>
                (matchLineupItems, mockRepo._repository);

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
