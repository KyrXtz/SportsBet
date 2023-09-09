namespace Infrastructure.Tests.EF.Sports
{
    public class SportsRepositoryTests : RepositoryTests
    {
        public SportsRepositoryTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition) : base(uniqueIdGeneratorDefinition) { }
        
        [Theory]
        [ClassData(typeof(CreateSportValidSeed))]
        public async Task Create_Sport_Success_Test(string sportName)
        {
            // Arrange
            var sport = new SportBuilder()
                .WithName(sportName)
                .Build();

            var sportsRepo = new EfRepository<Sport>(_dbContext);

            sport.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            // Act
            await sportsRepo.AddAsync(sport);
            var sports = await sportsRepo.ListAsync();

            // Assert
            var createdSport = await _dbContext.Sports.FindAsync(sport.Id);
            Assert.NotNull(createdSport);
            Assert.Equal(sport, createdSport);
            Assert.Equal(1, sports.Count);
        }

        [Theory]
        [ClassData(typeof(UpdateSportValidSeed))]
        public async Task Update_Sport_Success_Test(string sportName, string updatedSportName)
        {
            // Arrange
            var sport = new SportBuilder()
                .WithName(sportName)
                .Build();

            var sportsRepo = new EfRepository<Sport>(_dbContext);

            sport.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            await sportsRepo.AddAsync(sport);

            // Act
            sport.Update(updatedSportName);
            await sportsRepo.UpdateAsync(sport);

            // Assert
            var updatedSport = await _dbContext.Sports.FindAsync(sport.Id);
            Assert.Equal(updatedSportName, updatedSport.Name.Name);
        }
    }
}
