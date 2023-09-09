namespace Application.Tests.Commands.Sports
{
    public class CreateUpdateSportCommandHandlerTests
    {
        [Theory]
        [ClassData(typeof(CreateUpdateSportCommandValidSeed))]
        private async Task CreateUpdateCommand_ValidParameters(
            SportItem sportItem,
            int existingSportId,
            string existingSportName,
            int listAsyncTimesCalled,
            int addRangeAsyncTimesCalled,
            int updateRangeAsyncTimesCalled)
        {
            var existingSport = new SportBuilder()
                .WithId(existingSportId)
                .WithName(existingSportName)
                .Build();

            var existingSports = new List<Sport>() { existingSport };
            var sportItems = new List<SportItem>() { sportItem };

            var mockRepo = new MockRepository<Sport>(existingSports);

            var mockCommand = new MockCommand
                <Sport,CreateUpdateSportCommand, CreateUpdateSportCommandHandler, Result<List<int>>, SportItem>
                (sportItems, mockRepo._repository);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(
                listAsyncTimesCalled: listAsyncTimesCalled,
                addRangeAsyncTimesCalled: addRangeAsyncTimesCalled,
                updateRangeAsyncTimesCalled: updateRangeAsyncTimesCalled));
        }
    }
}
