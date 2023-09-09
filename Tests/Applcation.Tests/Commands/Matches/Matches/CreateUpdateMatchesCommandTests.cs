namespace Application.Tests.Commands.Matches.Matches
{
    public class CreateUpdateMatchsCommandTests
    {
        [Theory]
        [ClassData(typeof(CreateUpdateMatchsCommandValidSeed))]
        private async Task CreateUpdateCommand_ValidParameters(
            MatchItem matchItem,
            int existingmatchId,
            string existingmatchName,
            MatchStatus existingmatchStatus,
            DateTime existingmatchGameStart,
            int existingmatchHomeCompetitorId,
            int existingmatchAwayCompetitorId,
            int existingmatchSportId,
            int existingmatchLeagueId,
            int existingmatchScoreHome,
            int existingmatchScoreAway,
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
                .WithLeagueId(existingmatchLeagueId)
                .WithScore(existingmatchScoreHome, existingmatchScoreAway)
                .Build();

            var existingMatchs = new List<Match>() { existingMatch };
            var matchItems = new List<MatchItem>() { matchItem };

            var mockRepo = new MockRepository<Match>(existingMatchs);
            var mockCommand = new MockCommand
                <Match, CreateUpdateMatchsCommand, CreateUpdateMatchsCommandHandler, Result<List<int>>, MatchItem>
                (matchItems, mockRepo._repository);

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
