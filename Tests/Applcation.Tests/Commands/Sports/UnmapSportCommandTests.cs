namespace Application.Tests.Commands.Sports
{
    public class UnmapSportCommandTests
    {
        [Theory]
        [ClassData(typeof(UnmapSportCommandValidSeed))]
        private async Task UnmapCommand_ValidParameters(int sportId, int updateAsyncTimesCalled)
        {
            var existingSport = new SportBuilder()
                .WithId(sportId)
                .Build();

            var existingSports = new List<Sport>() { existingSport };

            var mockRepo = new MockRepository<Sport>(existingSports);

            var mockCommand = new MockCommand
                <Sport, UnmapSportCommand, UnmapSportCommandHandler, Result<Unit>>
                (mockRepo._repository, sportId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
