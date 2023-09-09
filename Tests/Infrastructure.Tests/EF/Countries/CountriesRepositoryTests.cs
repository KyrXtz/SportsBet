namespace Infrastructure.Tests.EF.Countries
{
    public class CountriesRepositoryTests : RepositoryTests
    {
        public CountriesRepositoryTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition) : base(uniqueIdGeneratorDefinition) { }
        
        [Theory]
        [ClassData(typeof(CreateCountryValidSeed))]
        public async Task Create_Country_Success_Test(string countryName)
        {
            // Arrange
            var country = new CountryBuilder()
                .WithName(countryName)
                .Build();

            var countriesRepo = new EfRepository<Country>(_dbContext);

            country.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            // Act
            await countriesRepo.AddAsync(country);
            var countries = await countriesRepo.ListAsync();

            // Assert
            var createdCountry = await _dbContext.Countries.FindAsync(country.Id);
            Assert.NotNull(createdCountry);
            Assert.Equal(country, createdCountry);
            Assert.Equal(1, countries.Count);
        }

        [Theory]
        [ClassData(typeof(UpdateCountryValidSeed))]
        public async Task Update_Country_Success_Test(string iSOCode, string name, int sportId, int providerId, string updatedISOCode, string UpdatedCountryName)
        {
            // Arrange
            var country = new CountryBuilder()
                 .WithName(name)
                 .WithCode(iSOCode)
                 .WithProviderId(providerId)
                 .WithBetContext(sportId, providerId, DateTime.UtcNow)
                 .Build();

            var countriesRepo = new EfRepository<Country>(_dbContext);

            country.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            await countriesRepo.AddAsync(country);

            // Act
            country.Update(updatedISOCode, UpdatedCountryName);
            await countriesRepo.UpdateAsync(country);

            // Assert
            var updatedCountry = await _dbContext.Countries.FindAsync(country.Id);
            Assert.Equal(updatedISOCode, updatedCountry.Name.ISOCode);
            Assert.Equal(UpdatedCountryName, updatedCountry.Name.Name);
        }
    }
}
