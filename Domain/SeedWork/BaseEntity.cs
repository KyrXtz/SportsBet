namespace SportsBet.Domain.SeedWork;

public abstract class BaseEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public byte[] RowVersion { get; set; }

    protected readonly List<BaseDomainEvent> _domainEvents = new(200);
    [NotMapped]
    public IReadOnlyList<BaseDomainEvent> Events => _domainEvents;

    protected void RaiseDomainEvent(BaseDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

public abstract class BaseEntity<TKey> : BaseEntity
{
    public TKey Id { get; protected set; }

    protected abstract void Validate();
}