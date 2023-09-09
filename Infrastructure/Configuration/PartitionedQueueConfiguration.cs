namespace SportsBet.Infrastructure.Configuration;
public static class PartitionedQueueConfiguration
{
    public static IServiceCollection AddPartitionedQueue(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();

        var partitionedQueueSettings =
            configuration?.GetSection(nameof(PartitionedQueueSettings)).Get<PartitionedQueueSettings>();

        if (partitionedQueueSettings == null)
            return services;

        //services.AddPartitionedQueue(configurator =>
        //{
            
        //});

        services.AddSingleton<FeedConsumerFactory>();

        return services;
    }
}