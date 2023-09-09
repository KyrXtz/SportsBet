namespace SportsBet.Infrastructure.MessageBroker
{
    class MessageAuditStore : IMessageAuditStore
    {
        private readonly ILogger<MessageAuditStore> _logger;

        public MessageAuditStore(ILogger<MessageAuditStore> logger)
        {
            _logger = logger;
        }

        public Task StoreMessage<T>(T message, MessageAuditMetadata metadata) where T : class
        {
            _logger.LogDebug($"{metadata.ContextType} {JsonConvert.SerializeObject(message)}");
            return Task.CompletedTask;
        }
    }
}

