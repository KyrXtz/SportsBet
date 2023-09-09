namespace SportsBet.Infrastructure.Decorators;
class PublisherMetricsDecorator<T> : IFeedQueuePublisher<T> where T : CommandBase
{
    private readonly IFeedQueuePublisher<T> _decorated;
    private readonly IInfrastructureMetrics _metrics;

    public PublisherMetricsDecorator(IFeedQueuePublisher<T> decorated,
        IInfrastructureMetrics metrics)
    {
        _decorated = decorated;
        _metrics = metrics;
    }

    public async Task Publish(long messageKey, T message)
    {
        var sw = Stopwatch.StartNew();
        var messageType = message.GetType();

        try
        {
            await _decorated.Publish(messageKey, message);

            _metrics.RecordPublishedQueueItem(sw.ElapsedMilliseconds, messageType, messageType.BaseType!.Name);
            _metrics.RecordVolume(1, messageType.FullName!);
            _metrics.RecordDuration(sw.ElapsedMilliseconds, messageType.FullName!);
        }
        catch
        {
            _metrics.RecordErroredQueueItem(sw.ElapsedMilliseconds, messageType!, messageType.BaseType!.Name);
            _metrics.RecordErroredVolume(1, messageType.FullName!);
            _metrics.RecordErroredDuration(sw.ElapsedMilliseconds, messageType.FullName!);
            throw;
        }
    }
}
