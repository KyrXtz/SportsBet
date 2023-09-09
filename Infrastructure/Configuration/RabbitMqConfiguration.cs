namespace SportsBet.Infrastructure.Configuration
{
    public static class RabbitMqConfiguration
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var configuration = serviceProvider.GetService<IConfiguration>();

            var options = configuration?.GetSection(nameof(BusSettings)).Get<BusSettings>();

            if (options is null)
                return services;

            services.AddMassTransit(cfg =>
            {
                cfg.SetKebabCaseEndpointNameFormatter();

                cfg.UsingRabbitMq((context, config) =>
                {
                    config.Host(new Uri(options.Host), h =>
                    {
                        h.Username(options.Username);
                        h.Password(options.Password);
                    });

                    config.ReceiveEndpoint($"{options.QueueNamePrefix}", endpoint =>
                    {
                        endpoint.SingleActiveConsumer = true;
                        endpoint.AutoDelete = options.AutoDelete;
                        endpoint.Durable = options.Durable;
                        endpoint.PrefetchCount = 1000;
                        endpoint.UseConcurrencyLimit(1);
                    });

                    var auditStore = new MessageAuditStore(context.GetService<ILogger<MessageAuditStore>>()!);

                    config.ConnectSendAuditObservers(auditStore);
                    config.ConnectConsumeAuditObserver(auditStore);
                });
            });
            
            return services;
        }
    }
}