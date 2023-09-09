namespace Domain.Tests.Aggregates.Countries
{
    [Collection("UniqueId Generator")]
    public class CountryTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public CountryTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {
            
        }
        [Theory]
        [ClassData(typeof(CountryValidSeed))]
        public void Create_ValidParameters(string iSOCode, string name, int sportId, int providerId)
        {
            //Arrange
            var country = new CountryBuilder()
                 .WithName(name)
                 .WithCode(iSOCode)
                 .WithProviderId(providerId)
                 .WithBetContext(sportId,providerId,DateTime.UtcNow)
                 .Build();

            //Assert
            Assert.NotNull(country);
            Assert.Equal(name, country.Name.Name);
            Assert.Equal(iSOCode, country.Name.ISOCode);
            Assert.Equal(sportId, country.SportId);
            Assert.Equal(providerId, country.ProviderId);
        }

        [Theory]
        [ClassData(typeof(CreateCountryInvalidSeed))]
        public void Create_InvalidParametersShouldFail(string iSOCode, string name, int sportId, int providerId)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var country = new CountryBuilder()
                 .WithName(name)
                 .WithCode(iSOCode)
                 .WithBetContext(sportId, providerId, DateTime.UtcNow)
                 .Build();

            });
        }

        [Theory]
        [ClassData(typeof(UpdateCountryValidSeed))]
        public void UpdateCountry_ValidParameters(string iSOCode, string name, int sportId, int providerId)
        {
            //Arrange
            var country = new CountryBuilder()
                 .WithName(name)
                 .WithCode(iSOCode)
                 .WithBetContext(sportId, providerId, DateTime.UtcNow)
                 .Build();

            //Act
            country.Update(country.Name.ISOCode, country.Name.Name);

            //Assert
            Assert.Equal(iSOCode, country.Name.ISOCode);
            Assert.Equal(name, country.Name.Name);

        }

        [Theory]
        [ClassData(typeof(UpdateCountryInvalidSeed))]
        public void UpdateCountry_InvalidParameters(string iSOCode, string name, int sportId, int providerId)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var country = new CountryBuilder()
                 .WithName(name)
                 .WithCode(iSOCode)
                 .WithBetContext(sportId, providerId, DateTime.UtcNow)
                 .Build();

            });
        }
    }
}
