namespace Application.Tests.Commands.Leagues
{
    public class UnmapLeagueCommandTests
    {
        [Theory]
        [ClassData(typeof(UnmapLeagueCommandValidSeed))]
        private async Task UnmapCommand_ValidParameters(int leagueId, int updateAsyncTimesCalled)
        {
            var existingLeague = new LeagueBuilder()
                .WithId(leagueId)
                .Build();

            var existingLeagues = new List<League>() { existingLeague };

            var mockRepo = new MockRepository<League>(existingLeagues);

            var mockCommand = new MockCommand
                <League, UnmapLeagueCommand, UnmapLeagueCommandHandler, Result<Unit>>
                (mockRepo._repository, leagueId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
