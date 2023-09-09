namespace Application.Tests.Commands.Players
{
    public class MapPlayerCommandTests
    {
        [Theory]
        [ClassData(typeof(MapPlayerCommandValidSeed))]
        private async Task MapCommand_ValidParameters(
            int playerId,
            int bBPlayerId,
            int mappingAgentId,
            int updateAsyncTimesCalled)
        {
            var existingPlayer = new PlayerBuilder()
                .WithId(playerId)
                .Build();

            var existingSports = new List<Player>() { existingPlayer };

            var mockRepo = new MockRepository<Player>(existingSports);

            var mockCommand = new MockCommand
                <Player, MapPlayerCommand, MapPlayerCommandHandler, Result<Unit>>
                (mockRepo._repository, playerId, bBPlayerId, mappingAgentId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
