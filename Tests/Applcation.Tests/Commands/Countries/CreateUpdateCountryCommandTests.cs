namespace Application.Tests.Commands.Countries
{
    [Collection("UniqueId Generator")]
    public class CreateUpdateCountryCommandTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public CreateUpdateCountryCommandTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {

        }

        [Theory]
        [ClassData(typeof(CreateUpdateCountryCommandValidSeed))]
        private async Task CreateUpdateCommand_ValidParameters(
            CountryItem countryItem,
            string existingCode,
            string existingCountryName,
            int existingSportId,
            int existingProviderId,
            int listAsyncTimesCalledFromSeed,
            int addRangeAsyncTimesCalledFromSeed,
            int updateRangeAsyncTimesCalledFromSeed
            )
        {
            var existingCountry = new CountryBuilder()
                .WithCode(existingCode)
                .WithName(existingCountryName)
                .WithSportId(existingSportId)
                .WithProviderId(existingProviderId)
                .Build();

            var existingCountries = new List<Country>() { existingCountry };
            var countryItems = new List<CountryItem>() { countryItem };

            var mockRepo = new MockRepository<Country>(existingCountries);

            var mockCommand = new MockCommand
                <Country, CreateUpdateCountryCommand, CreateUpdateCountryCommandHandler, Result<List<long>>, CountryItem>
                (countryItems, mockRepo._repository);

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
