namespace Application.Tests.Commands.Players
{
    public class UnmapPlayerCommandTests
    {
        [Theory]
        [ClassData(typeof(UnmapPlayerCommandValidSeed))]
        private async Task UnmapCommand_ValidParameters(int playerId, int updateAsyncTimesCalled)
        {
            var existingPlayer = new PlayerBuilder()
                .WithId(playerId)
                .Build();

            var existingPlayers = new List<Player>() { existingPlayer };

            var mockRepo = new MockRepository<Player>(existingPlayers);

            var mockCommand = new MockCommand
                <Player, UnmapPlayerCommand, UnmapPlayerCommandHandler, Result<Unit>>
                (mockRepo._repository, playerId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
