namespace Application.Tests.Commands.Countries
{
    [Collection("UniqueId Generator")]
    public class MapCountryCommandTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public MapCountryCommandTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {

        }

        [Theory]
        [ClassData(typeof(MapCountryCommandValidSeed))]
        private async Task MapCommand_ValidParameters(
            int bBRegionId,
            int mappingAgentId,
            int updateAsyncTimesCalled
            )
        {
            var existingCountry = new CountryBuilder()
                .Build();

            var existingCountries = new List<Country>() { existingCountry };

            var mockRepo = new MockRepository<Country>(existingCountries);

            var mockCommand = new MockCommand
                <Country, MapCountryCommand, MapCountryCommandHandler, Result<Unit>>
                (mockRepo._repository, existingCountry.Id, bBRegionId, mappingAgentId);

            var res = await mockCommand.Execute();

            Assert.True(res);
            Assert.True(mockRepo.Verify(updateAsyncTimesCalled: updateAsyncTimesCalled));
        }
    }
}
