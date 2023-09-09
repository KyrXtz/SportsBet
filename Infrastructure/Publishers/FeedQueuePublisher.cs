namespace SportsBet.Infrastructure.Publishers;
class FeedQueuePublisher<T> : IFeedQueuePublisher<T> where T : CommandBase
{
    private readonly IPartitionedQueuePublisher _publisher;
    private readonly ISerializationService _serializationService;
    public FeedQueuePublisher(IPartitionedQueuePublisher publisher, ISerializationService serializationService)
    {
        _publisher = publisher;
        _serializationService = serializationService;
    }

    public Task Publish(long messageKey, T message)
    {
        var serializedMessage = _serializationService.Serialize(message);
        _publisher.Publish(messageKey, serializedMessage);

        return Task.CompletedTask;
    }
}