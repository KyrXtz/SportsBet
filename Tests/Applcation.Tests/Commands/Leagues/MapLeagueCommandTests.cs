namespace Application.Tests.Commands.Leagues
{
    public class MapLeagueCommandTests
    {
        [Theory]
        [ClassData(typeof(MapLeagueCommandValidSeed))]
        private async Task MapCommand_ValidParameters(
            int leagueId,
            int bBCompetitionId,
            int mappingAgentId,
            int updateAsyncTimesCalled
            )
        {
            var existingLeague = new LeagueBuilder()
                .WithId(leagueId)
                .Build();

            var existingLeagues = new List<League>() { existingLeague };

            var mockRepo = new MockRepository<League>(existingLeagues);

            var mockCommand = new MockCommand
                <League, MapLeagueCommand, MapLeagueCommandHandler, Result<Unit>>
                (mockRepo._repository, leagueId, bBCompetitionId, mappingAgentId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
