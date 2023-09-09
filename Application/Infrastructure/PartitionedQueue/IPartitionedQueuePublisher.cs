namespace SportsBet.Application.Infrastructure.PartitionedQueue;

public interface IPartitionedQueuePublisher
{
	string QueueId { get; }

	void Publish(long key, byte[] message);
}