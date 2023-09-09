namespace Infrastructure.Tests.EF.Players
{
    public class PlayerRepositoryTests : RepositoryTests
    {
        public PlayerRepositoryTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition) : base(uniqueIdGeneratorDefinition) { }

        [Theory]
        [ClassData(typeof(CreatePlayerValidSeed))]
        public async Task Create_Player_Success_Test(
            int id,
            string name,
            PlayerPosition position,
            int providerCountryId
            )
        {
            // Arrange
            var player = new PlayerBuilder()
                .WithId(id)
                .WithName(name)
                .WithPlayerPosition(position)
                .WithProviderCountryId(providerCountryId)
                .Build();

            var playersRepo = new EfRepository<Player>(_dbContext);

            player.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            // Act
            await playersRepo.AddAsync(player);
            var players = await playersRepo.ListAsync();

            // Assert
            var createdPlayer = await _dbContext.Players.FindAsync(player.Id);
            Assert.NotNull(createdPlayer);
            Assert.Equal(player, createdPlayer);
            Assert.Equal(1, players.Count);
        }

        [Theory]
        [ClassData(typeof(UpdatePlayerValidSeed))]
        public async Task Update_Player_Success_Test(string playerName, string updatePlayerName)
        {
            // Arrange
            var player = new PlayerBuilder()
                .WithName(playerName)
                .Build();

            var playersRepo = new EfRepository<Player>(_dbContext);

            player.RowVersion = Encoding.UTF8.GetBytes("0x00000000000007D3");

            await playersRepo.AddAsync(player);

            // Act
            player.Update(updatePlayerName);
            await playersRepo.UpdateAsync(player);

            // Assert
            var updatedPlayer = await _dbContext.Players.FindAsync(player.Id);
            Assert.Equal(updatePlayerName, updatedPlayer.Name.Name);
        }
    }
}
