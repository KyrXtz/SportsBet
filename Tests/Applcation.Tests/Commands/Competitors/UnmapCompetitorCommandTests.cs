namespace Application.Tests.Commands.Competitors
{
    public class UnmapCompetitorCommandTests
    {
        [Theory]
        [ClassData(typeof(UnmapCompetitorCommandValidSeed))]
        private async Task UnmapCommand_ValidParameters(int competitorId, int updateAsyncTimesCalled)
        {
            var existingCompetitor = new CompetitorBuilder()
                .WithId(competitorId)
                .Build();

            var existingCompetitors = new List<Competitor>() { existingCompetitor };

            var mockRepo = new MockRepository<Competitor>(existingCompetitors);

            var mockCommand = new MockCommand
                <Competitor, UnmapCompetitorCommand, UnmapCompetitorCommandHandler, Result<Unit>>
                (mockRepo._repository, competitorId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
