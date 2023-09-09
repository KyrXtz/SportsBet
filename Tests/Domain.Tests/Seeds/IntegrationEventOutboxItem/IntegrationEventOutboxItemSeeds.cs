namespace Domain.Tests.Seeds.IntegrationEventOutboxItem
{
    public class IntegrationEventOutboxItemValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Guid.NewGuid(), "integrationEventOutboxItemName", "data" };
        }
    }
    public class IntegrationEventOutboxItemInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null, null }; 
        }
    }
    public class UpdateIntegrationEventOutboxItemStatusValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var eventLogStatus in IntegrationEventOutboxItemStatus.List)
            {
                yield return new object[] { eventLogStatus };
            }
        }
    }
}
