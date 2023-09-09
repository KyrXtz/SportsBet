namespace Application.Tests.Commands.Matches.Matches
{
    public class UnmapMatchsCommandTests
    {
        [Theory]
        [ClassData(typeof(UnmapMatchsCommandValidSeed))]
        private async Task UnmapCommand_ValidParameters(int matchId, int updateAsyncTimesCalled)
        {
            var existingMatch = new MatchBuilder()
                .WithId(matchId)
                .Build();

            var existingexistingMatchs = new List<Match>() { existingMatch };

            var mockRepo = new MockRepository<Match>(existingexistingMatchs);

            var mockCommand = new MockCommand
                <Match, UnmapMatchCommand, UnmapMatchCommandHandler, Result<Unit>>
                (mockRepo._repository, matchId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
