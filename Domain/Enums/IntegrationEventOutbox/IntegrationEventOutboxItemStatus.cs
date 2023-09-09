namespace SportsBet.Domain.Enums.EventLogs
{
    public sealed class IntegrationEventOutboxItemStatus : SmartEnum<IntegrationEventOutboxItemStatus>
    {
        public static readonly IntegrationEventOutboxItemStatus NotPublished = new IntegrationEventOutboxItemStatus(nameof(NotPublished), 1);
        public static readonly IntegrationEventOutboxItemStatus InProgress = new IntegrationEventOutboxItemStatus(nameof(InProgress), 2);
        public static readonly IntegrationEventOutboxItemStatus Published = new IntegrationEventOutboxItemStatus(nameof(Published), 3);
        public static readonly IntegrationEventOutboxItemStatus PublishedFailed = new IntegrationEventOutboxItemStatus(nameof(PublishedFailed), 4);
        public static readonly IntegrationEventOutboxItemStatus Failed = new IntegrationEventOutboxItemStatus(nameof(Failed), 5);

        private IntegrationEventOutboxItemStatus() : base(default, default) { }

        public IntegrationEventOutboxItemStatus(string name, int value) : base(name, value) { }
    }
}

