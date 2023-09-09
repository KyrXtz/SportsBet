namespace SportsBet.Application.Infrastructure.PartitionedQueue;

public interface IPartitionedQueueConsumerFactory
{
	IPartitionedQueueConsumer Create(string partitionId);
}
