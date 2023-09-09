namespace Application.Tests.Commands.Competitors
{
    public class MapCompetitorCommandTests
    {
        [Theory]
        [ClassData(typeof(MapCompetitorCommandValidSeed))]
        private async Task MapCommand_ValidParameters(int competitorId, int bBCompetitorId, int mappingAgentId, int updateAsyncTimesCalled)
        {
            var existingCompetitor = new CompetitorBuilder()
                .WithId(competitorId)
                .Build();

            var existingCompetitors = new List<Competitor>() { existingCompetitor };

            var mockRepo = new MockRepository<Competitor>(existingCompetitors);

            var mockCommand = new MockCommand
                <Competitor, MapCompetitorCommand, MapCompetitorCommandHandler, Result<Unit>>
                (mockRepo._repository, competitorId, bBCompetitorId, mappingAgentId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
