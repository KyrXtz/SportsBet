namespace SportsBet.Domain.ValueObjects.EventLogs
{
    public class IntegrationEventOutboxItemIdentity : ValueObject
    {
        public Guid EventId { get; private set; }
        public string EventName { get; private set; }

        internal IntegrationEventOutboxItemIdentity(Guid eventId, string eventName)
        {
            EventId = Guard.Against.Null(eventId, nameof(eventId));
            EventName = Guard.Against.NullOrWhiteSpace(eventName, nameof(eventName));
        }

        public static IntegrationEventOutboxItemIdentity Create(Guid eventId, string eventName)
        {
            return new IntegrationEventOutboxItemIdentity(eventId, eventName);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EventId;
            yield return EventName;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

