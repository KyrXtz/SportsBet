namespace SportsBet.Domain.Events.Players
{
    public class PlayerAddedEvent : BaseDomainEvent
    {
        public Player NewPlayer { get; private set; }

        public PlayerAddedEvent(Player newPlayer)
        {
            NewPlayer = newPlayer;
        }
    }

    public class PlayerUpdatedEvent : BaseDomainEvent
    {
        public Player UpdatedPlayer { get; private set; }

        public PlayerUpdatedEvent(Player updatedPlayer)
        {
            UpdatedPlayer = updatedPlayer;
        }
    }

    public class PlayerMappedEvent : BaseDomainEvent
    {
        public Player MappedPlayer { get; private set; }

        public PlayerMappedEvent(Player mappedPlayer)
        {
            MappedPlayer = mappedPlayer;
        }
    }

    public class PlayerUnmappedEvent : BaseDomainEvent
    {
        public Player UnmappedPlayer { get; private set; }

        public PlayerUnmappedEvent(Player unmappedPlayer)
        {
            UnmappedPlayer = unmappedPlayer;
        }
    }
}
