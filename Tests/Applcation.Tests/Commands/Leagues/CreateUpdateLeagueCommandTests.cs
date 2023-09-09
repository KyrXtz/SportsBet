namespace Application.Tests.Commands.Leagues
{
    public class CreateUpdateLeagueCommandTests
    {
        [Theory]
        [ClassData(typeof(CreateUpdateLeagueCommandValidSeed))]
        private async Task CreateUpdateCommand_ValidParameters(
            LeagueItem leagueItem,
            int leagueId,
            string existingLeagueName,
            long existingCountryId,
            int existingSportId,
            int listAsyncTimesCalledFromSeed,
            int addRangeAsyncTimesCalledFromSeed,
            int updateRangeAsyncTimesCalledFromSeed
            )
        {
            var existingLeague = new LeagueBuilder()
                .WithId(leagueId)
                .WithName(existingLeagueName)
                .WithCountryId(existingCountryId)
                .WithSportId(existingSportId)
                .Build();

            var existingLeagues = new List<League>() { existingLeague };
            var leagueItems = new List<LeagueItem>() { leagueItem };

            var mockRepo = new MockRepository<League>(existingLeagues);

            var mockCommand = new MockCommand
                <League, CreateUpdateLeagueCommand, CreateUpdateLeagueCommandHandler, Result<List<int>>, LeagueItem>
                (leagueItems, mockRepo._repository);

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
