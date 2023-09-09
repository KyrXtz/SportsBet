namespace SportsBet.Infrastructure.Configuration
{
    public static class DefaultConfiguration
    {
        public static IServiceCollection AddDefaultServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            var configuration = serviceProvider.GetService<IConfiguration>();

            services.AddOptions();
            services.Configure<GeneralSettings>(configuration?.GetSection(nameof(GeneralSettings)));
            services.Configure<BusSettings>(configuration?.GetSection(nameof(BusSettings)));

            services.AddHttpContextAccessor();

            services.AddHostedService<HealthChecksHostedService>();
            services.AddHostedService<NLogMetricsHostedService>();
            services.AddHostedService<DatabaseSizeCollectorHostedService>();

            return services;
        }
    }
}