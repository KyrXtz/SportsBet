namespace Application.Tests.Commands.Competitors
{
    public class CreateUpdateCompetitorCommandTests
    {
        [Theory]
        [ClassData(typeof(CreateUpdateCompetitorCommandValidSeed))]
        private async Task CreateUpdateCommand_ValidParameters(
            CompetitorItem competitorItem,
            string existingCompetitorName,
            int listAsyncTimesCalledFromSeed,
            int addRangeAsyncTimesCalledFromSeed,
            int updateRangeAsyncTimesCalledFromSeed
            )
        {
            var existingCompetitor = new CompetitorBuilder()
                .WithName(existingCompetitorName)
                .Build();

            var existingCompetitors = new List<Competitor>() { existingCompetitor };
            var competitorItems = new List<CompetitorItem>() { competitorItem };

            var mockRepo = new MockRepository<Competitor>(existingCompetitors);

            var mockCommand = new MockCommand
                <Competitor, CreateUpdateCompetitorCommand, CreateUpdateCompetitorCommandHandler, Result<List<int>>, CompetitorItem>
                (competitorItems, mockRepo._repository);

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
