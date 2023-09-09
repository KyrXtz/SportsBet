namespace Application.Tests.Commands.Countries
{
    [Collection("UniqueId Generator")]
    public class UnmapCountryCommandTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public UnmapCountryCommandTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {

        }

        [Theory]
        [ClassData(typeof(UnmapCountryCommandValidSeed))]
        private async Task UnmapCommand_ValidParameters(int updateAsyncTimesCalled)
        {
            var existingCountry = new CountryBuilder()
                .Build();

            var existingCountries = new List<Country>() { existingCountry };

            var mockRepo = new MockRepository<Country>(existingCountries);

            var mockCommand = new MockCommand
                <Country, UnmapCountryCommand, UnmapCountryCommandHandler, Result<Unit>>
                (mockRepo._repository, existingCountry.Id);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
