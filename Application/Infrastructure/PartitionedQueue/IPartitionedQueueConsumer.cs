namespace SportsBet.Application.Infrastructure.PartitionedQueue;

public interface IPartitionedQueueConsumer
{
	Task Consume(byte[] message, CancellationToken cancellationToken);

	void NotifyDone()
	{
	}
}
