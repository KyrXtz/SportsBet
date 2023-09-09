namespace Application.Tests.Commands.Matches.Matches
{
    public class MapMatchsCommandTests
    {
        [Theory]
        [ClassData(typeof(MapMatchsCommandValidSeed))]
        private async Task MapCommand_ValidParameters(
            int matchsId,
            int bBCompetitionHistoryId,
            int mappingAgentId,
            int updateAsyncTimesCalled
            )
        {
            var existingMatch = new MatchBuilder()
                .Build();

            var existingexistingMatchs = new List<Match>() { existingMatch };

            var mockRepo = new MockRepository<Match>(existingexistingMatchs);
            var mockCommand = new MockCommand
                <Match, MapMatchCommand, MapMatchCommandHandler, Result<Unit>>
                (mockRepo._repository, matchsId, bBCompetitionHistoryId, mappingAgentId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
