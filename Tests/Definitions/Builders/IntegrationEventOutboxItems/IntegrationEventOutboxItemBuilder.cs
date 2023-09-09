namespace TestDefinitions.Builders.IntegrationEventOutboxItems
{
    public class IntegrationEventOutboxItemBuilder
    {
        private int id = 1;
        private string name = "integrationEventOutboxItemName";
        private string data = "data";
        private Guid eventId = Guid.NewGuid();
        private int value = 1;

        public IntegrationEventOutboxItem Build()
        {
            var integrationEventOutboxItem = IntegrationEventOutboxItem.Create(eventId, name, data);

            return integrationEventOutboxItem;
        }
        public IntegrationEventOutboxItemBuilder WithIntegrationEventOutboxItemIdentity(Guid eventId, string name)
        {
            this.eventId = eventId;
            this.name = name;
            return this;
        }
        public IntegrationEventOutboxItemBuilder WithIntegrationEventOutboxItemData(string data)
        {
            this.data = data;
            return this;
        }
        public IntegrationEventOutboxItemBuilder WithIntegrationEventOutboxItemStatus(int value)
        {
            this.value = value;
            return this;
        }

        public static implicit operator IntegrationEventOutboxItem(IntegrationEventOutboxItemBuilder instance)
        {
            return instance.Build();
        }
    }
}
