namespace Application.Tests.Commands.Players
{
    public class CreateUpdatePlayerCommandTests
    {
        [Theory]
        [ClassData(typeof(CreateUpdatePlayerCommandValidSeed))]
        private async Task CreateUpdateCommand_ValidParameters(
            PlayerItem playerItem,
            int id,
            string name,
            PlayerPosition position,
            int providerCountryId,
            int listAsyncTimesCalledFromSeed,
            int addRangeAsyncTimesCalledFromSeed,
            int updateRangeAsyncTimesCalledFromSeed
            )
        {
            var existingPlayer = new PlayerBuilder()
                .WithId( id )
                .WithName(name)
                .WithPlayerPosition(position)
                .WithProviderCountryId(providerCountryId)
                .Build();

            var existingPlayers = new List<Player>() { existingPlayer };
            var playerItems = new List<PlayerItem>() { playerItem };

            var mockRepo = new MockRepository<Player>(existingPlayers);
            var mockCommand = new MockCommand
                <Player, CreateUpdatePlayersCommand, CreateUpdatePlayersCommandHandler, Result<List<int>>, PlayerItem>
                (playerItems, mockRepo._repository);

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
