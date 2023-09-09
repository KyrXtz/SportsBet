namespace SportsBet.Domain.Aggregates.Players;
public class Player : BaseEntity<int>, IAggregateRoot
{
    public PlayerName Name { get; private set; }
    public PlayerPosition Position { get; private set; }
    public PlayerBetContext BetContext { get; private set; }
    public int ProviderCountryId { get; private set; }

    private Player() { }

    internal Player(int id,
        PlayerName name,
        PlayerPosition position,
        int providerCountryId)
    {
        Id = Guard.Against.InvalidInput(id, nameof(id), id => id > 0);
        Name = name;
        Position = position;
        ProviderCountryId = Guard.Against.InvalidInput(providerCountryId, nameof(providerCountryId), providerCountryId => providerCountryId >= 0);

        _domainEvents.Add(new PlayerAddedEvent(this));
    }

    public static Player Create(int id,
        string name,
        PlayerPosition position,
        int providerCountryId)
    {
        var playerName = PlayerName.Create(name: name);

        var player = new Player(id: id,
            name: playerName,
            position: position,
            providerCountryId: providerCountryId);

        return player;
    }

    public void Update(string name)
    {
        var playerName = PlayerName.Create(name: name);

        Name = playerName;

        _domainEvents.Add(new PlayerUpdatedEvent(this));
    }

    public void UpdatePlayerName(PlayerName playerName)
    {
        Name = playerName;

        _domainEvents.Add(new PlayerUpdatedEvent(this));
    }

    public void UpdatePlayerPosition(PlayerPosition playerPosition)
    {
        Position = playerPosition;

        _domainEvents.Add(new PlayerUpdatedEvent(this));
    }

    public void Map(int bBPlayerId, int mappingAgentId)
    {
        var playerBetContext = PlayerBetContext.Create(bBPlayerId: bBPlayerId,
            mappingAgentId: mappingAgentId,
            mappedAt: DateTime.UtcNow);

        BetContext = playerBetContext;

        _domainEvents.Add(new PlayerMappedEvent(this));
    }

    public void Unmap()
    {
        var playerBetContext = PlayerBetContext.Create(bBPlayerId: null,
            mappingAgentId: null,
            mappedAt: null);

        BetContext = playerBetContext;

        _domainEvents.Add(new PlayerUnmappedEvent(this));
    }
    public bool IsMapped()
    {
        return BetContext != null && BetContext.BBPlayerId != default;
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}