namespace SportsBet.Domain.ValueObjects.EventLogs
{
    public class IntegrationEventOutboxItemData : ValueObject
    {
        public string Data { get; private set; }

        internal IntegrationEventOutboxItemData(string data)
        {
            Data = Guard.Against.NullOrWhiteSpace(data, nameof(data));
        }

        public static IntegrationEventOutboxItemData Create(string data)
        {
            return new IntegrationEventOutboxItemData(data);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Data;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

