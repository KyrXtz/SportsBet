namespace SportsBet.Domain.SeedWork
{
    public abstract class BaseDomainEvent : INotification
    {
        public Guid EventId { get; protected set; } = Guid.NewGuid();
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
