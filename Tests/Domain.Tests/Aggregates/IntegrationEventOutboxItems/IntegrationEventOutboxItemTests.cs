namespace Domain.Tests.Aggregates.IntegrationEventOutboxItems
{
    [Collection("UniqueId Generator")]
    public class IntegrationEventOutboxItemTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public IntegrationEventOutboxItemTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {
            
        }
        [Theory]
        [ClassData(typeof(IntegrationEventOutboxItemValidSeed))]
        public void Create_ValidParameters(
            Guid eventId,
            string name,
            string data
            )
        {
            var integrationEventOutboxItem = new IntegrationEventOutboxItemBuilder()
                .WithIntegrationEventOutboxItemIdentity(eventId, name)
                .WithIntegrationEventOutboxItemData(data)
                .Build();

            Assert.NotNull(integrationEventOutboxItem);
            Assert.Equal(eventId, integrationEventOutboxItem.EventIdentity.EventId);
            Assert.Equal(name, integrationEventOutboxItem.EventIdentity.EventName);
            Assert.Equal(data, integrationEventOutboxItem.EventData.Data);
        }

        [Theory]
        [ClassData(typeof(IntegrationEventOutboxItemInvalidSeed))]
        public void Create_InvalidParameters(
            Guid eventId,
            string name,
            string data
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var integrationEventOutboxItem = new IntegrationEventOutboxItemBuilder()
                .WithIntegrationEventOutboxItemIdentity(eventId, name)
                .WithIntegrationEventOutboxItemData(data)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateIntegrationEventOutboxItemStatusValidSeed))]
        public void UpdateIntegrationEventOutboxItemStatus_ValidParameters(IntegrationEventOutboxItemStatus eventLogStatus)
        {
            var integrationEventOutboxItem = new IntegrationEventOutboxItemBuilder()
                .WithIntegrationEventOutboxItemStatus(eventLogStatus)
                .Build();

            integrationEventOutboxItem.UpdateIntegrationEventOutboxItemStatus(eventLogStatus);

            Assert.NotNull(integrationEventOutboxItem);
            Assert.Equal(eventLogStatus, integrationEventOutboxItem.Status);
        }
    }
}
