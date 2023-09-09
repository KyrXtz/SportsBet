namespace TestDefinitions.Builders.Players
{
    public class PlayerBuilder
    {
        private int id = 1;
        private string name = "PlayerName";
        private int value = 1;
        private int providerCountryId = 1;
        private int bBPlayerId = 1;
        private int mappingAgentId = 1;

        public Player Build()
        {
            var position = new PlayerPosition(name, value);
            var player = Player.Create(id, name, position, providerCountryId);
            player.Map(bBPlayerId, mappingAgentId);
            return player;
        }
        public PlayerBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }
        public PlayerBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public PlayerBuilder WithPlayerPosition(int value)
        {
            this.value = value;
            return this;
        }
        public PlayerBuilder WithProviderCountryId(int providerCountryId)
        {
            this.providerCountryId = providerCountryId;
            return this;
        }
        public PlayerBuilder WithBetContext(int bBPlayerId, int mappingAgentId)
        {
            this.bBPlayerId = bBPlayerId;
            this.mappingAgentId = mappingAgentId;
            return this;
        }

        public static implicit operator Player(PlayerBuilder instance)
        {
            return instance.Build();
        }
    }
}
