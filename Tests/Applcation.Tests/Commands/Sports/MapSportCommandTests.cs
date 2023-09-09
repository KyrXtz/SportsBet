namespace Application.Tests.Commands.Sports
{
    public class MapSportCommandTests
    {
        [Theory]
        [ClassData(typeof(MapSportCommandValidSeed))]
        private async Task MapCommand_ValidParameters(int sportId, int bBCompetitionContextId, int mappingAgentId, int updateAsyncTimesCalled)
        {
            var existingSport = new SportBuilder()
                .WithId(sportId)
                .Build();

            var existingSports = new List<Sport>() { existingSport };

            var mockRepo = new MockRepository<Sport>(existingSports);

            var mockCommand = new MockCommand
                <Sport, MapSportCommand, MapSportCommandHandler, Result<Unit>>
                (mockRepo._repository,sportId,bBCompetitionContextId,mappingAgentId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
