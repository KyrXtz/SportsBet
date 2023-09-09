namespace SportsBet.Domain.Aggregates.IntegrationEventOutbox
{
    public class IntegrationEventOutboxItem : BaseEntity<long>, IAggregateRoot
    {
        public IntegrationEventOutboxItemIdentity EventIdentity { get; private set; }
        public IntegrationEventOutboxItemData EventData { get; private set; }
        public IntegrationEventOutboxItemStatus Status { get; private set; }

        private IntegrationEventOutboxItem() { }

        internal IntegrationEventOutboxItem(IntegrationEventOutboxItemIdentity eventIdentity, IntegrationEventOutboxItemData eventData)
        {
            Id = UniqueIdGenerator.CreateId();
            EventIdentity = eventIdentity;
            EventData = eventData;
            Status = IntegrationEventOutboxItemStatus.NotPublished;
        }

        public static IntegrationEventOutboxItem Create(Guid eventId,
            string name,
            string data)
        {
            var eventLogIdentity = IntegrationEventOutboxItemIdentity.Create(eventId: eventId,
                eventName: name);
            var eventLogData = IntegrationEventOutboxItemData.Create(data: data);

            return new IntegrationEventOutboxItem(eventIdentity: eventLogIdentity,
                eventData: eventLogData);
        }

        public void UpdateIntegrationEventOutboxItemStatus(IntegrationEventOutboxItemStatus eventLogStatus)
        {
            Status = eventLogStatus;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

