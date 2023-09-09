namespace SportsBet.Infrastructure.Configuration;
public static class PartitionedQueueConfiguration
{
    public static IServiceCollection AddPartitionedQueue(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();

        var redisConnection =
            configuration.GetSection(nameof(RedisConnectionSettings)).Get<RedisConnectionSettings>().ConnectionString;

        var partitionedQueueSettings =
            configuration?.GetSection(nameof(PartitionedQueueSettings)).Get<PartitionedQueueSettings>();

        if (partitionedQueueSettings == null)
            return services;

        services.AddPartitionedQueue(configurator =>
        {
            configurator.AddRedisPublisher(new RedisPublisherSettings
            {
                QueueId = partitionedQueueSettings.QueueId,
                ConnectionString = redisConnection,
                MaxStreamLength = partitionedQueueSettings.MaxStreamLength
            });

            configurator.AddRedisConsumers<FeedConsumerFactory>(new RedisNodeSettings
            {
                QueueId = partitionedQueueSettings.QueueId,
                ConnectionString = redisConnection,
                NodeId = Environment.MachineName,
                Leader = new RedisNodeSettings.LeaderSettings
                {
                    PartitionCount = partitionedQueueSettings.PartitionCount
                }
            })
            .UseConsulLeadershipElection(new ConsulLeadershipElectionSettings
            {
                ConsulUrl = Environment.GetEnvironmentVariable("CONSULURL"),
                ConsulToken = Environment.GetEnvironmentVariable("CONSULTOKEN"),
                LeadershipPath = partitionedQueueSettings.LeadershipPath
            });
        });

        services.AddSingleton<FeedConsumerFactory>();

        return services;
    }
}