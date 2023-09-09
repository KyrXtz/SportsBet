namespace SportsBet.Infrastructure.Consumers.Feed;
class FeedConsumerFactory : IPartitionedQueueConsumerFactory
{
    private readonly IServiceScopeFactory _serviceProviderScopeFactory;
    private readonly ISerializationService _serializationService;
    private readonly ILogger<FeedConsumer> _logger;

    public FeedConsumerFactory(IServiceScopeFactory serviceProviderScopeFactory, ISerializationService serializationService, ILogger<FeedConsumer> logger)
    {
        _serviceProviderScopeFactory = serviceProviderScopeFactory;
        _serializationService = serializationService;
        _logger = logger;
    }

    public IPartitionedQueueConsumer Create(string partitionId) => new FeedConsumer(_serviceProviderScopeFactory, _serializationService, _logger);
}