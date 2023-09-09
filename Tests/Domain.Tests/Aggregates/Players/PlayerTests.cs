namespace Domain.Tests.Aggregates.Players
{
    public class PlayerTests
    {
        [Theory]
        [ClassData(typeof(PlayerValidSeed))]
        public void Create_ValidParameters(
            int id,
            string name,
            PlayerPosition position,
            int providerCountryId
            )
        {
            var player = new PlayerBuilder()
                .WithId(id)
                .WithName(name)
                .WithPlayerPosition(position)
                .WithProviderCountryId(providerCountryId)
                .Build();

            Assert.NotNull(player);
            Assert.Equal(id, player.Id);
            Assert.Equal(name, player.Name.Name);
            Assert.Equal(position, player.Position);
            Assert.Equal(providerCountryId, player.ProviderCountryId);
        }

        [Theory]
        [ClassData(typeof(PlayerInvalidSeed))]
        public void Create_InvalidParameters(
            int id,
            string name,
            PlayerPosition position,
            int providerCountryId
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var player = new PlayerBuilder()
                .WithId(id)
                .WithName(name)
                .WithPlayerPosition(position)
                .WithProviderCountryId(providerCountryId)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdatePlayerValidSeed))]
        public void UpdatePlayer_ValidParameters(string name)
        {
            //Arrange
            var player = new PlayerBuilder()
                .Build();

            //Act
            player.Update(name);

            //Assert
            Assert.Equal(name, player.Name.Name);
        }

        [Theory]
        [ClassData(typeof(UpdatePlayerInvalidSeed))]
        public void UpdatePlayer_InvalidParameters(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var player = new PlayerBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdatePlayerNameValidSeed))]
        public void UpdatePlayerName_ValidParameters(string name)
        {
            //Arrange
            var player = new PlayerBuilder()
                .Build();

            var playerName = PlayerName.Create(name);

            //Act
            player.UpdatePlayerName(playerName);

            //Assert
            Assert.Equal(name, player.Name.Name);
        }

        [Theory]
        [ClassData(typeof(UpdatePlayerNameInvalidSeed))]
        public void UpdatePlayerName_InvalidParameters(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var player = new PlayerBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(MapPlayerValidSeed))]
        public void MapPlayer_ValidParameters(int oldBBPlayerId, int oldMappingAgentId, int newBBPlayerId, int newMappingAgentId)
        {
            //Arrange
            var player = new PlayerBuilder()
                .WithBetContext(oldBBPlayerId, oldMappingAgentId)
                .Build();

            //Act
            player.Map(newBBPlayerId, newMappingAgentId);

            //Assert
            Assert.Equal(newBBPlayerId, player.BetContext.BBPlayerId);
            Assert.Equal(newMappingAgentId, player.BetContext.MappingAgentId);
        }

        [Theory]
        [ClassData(typeof(UnMapPlayerValidSeed))]
        public void UnMapPlayer_ValidParameters(int bBPlayerId, int mappingAgentId)
        {
            //Arrange
            var player = new PlayerBuilder()
                .WithBetContext(bBPlayerId, mappingAgentId)
                .Build();

            //Act
            player.Unmap();

            //Assert
            Assert.Null(player.BetContext.BBPlayerId);
            Assert.Null(player.BetContext.MappingAgentId);
        }
    }
}
