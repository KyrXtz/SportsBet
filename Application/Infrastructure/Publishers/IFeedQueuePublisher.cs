namespace SportsBet.Application.Infrastructure.Publishers;

public interface IFeedQueuePublisher<T> where T : CommandBase
{
    Task Publish(long messageKey, T message);
}