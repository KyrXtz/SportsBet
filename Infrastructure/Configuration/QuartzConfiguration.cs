namespace SportsBet.Infrastructure.Configuration
{
    public static class QuartzConfiguration
    {
        public static IServiceCollection AddQuartz(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            services.Configure<QuartzOptions>(options =>
            {
                options.Scheduling.IgnoreDuplicates = true;
                options.Scheduling.OverWriteExistingData = false;
            });

            services.AddQuartz(options =>
            {
                options.SchedulerId = $"SportsBet-{Environment.MachineName}";
                options.SchedulerName = "SportsBet";

                options.UseMicrosoftDependencyInjectionJobFactory();

                options.UseSimpleTypeLoader();
                options.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });

                options.UseJobFactory<JobFactory>();

                options.UsePersistentStore(s =>
                {
                    s.UseProperties = false;
                    s.RetryInterval = TimeSpan.FromSeconds(15);
                    s.UseSqlServer(sqlServer =>
                    {
                        sqlServer.ConnectionString = configuration.GetSection(nameof(SqlConnectionSettings)).Get<SqlConnectionSettings>().ConnectionString;
                        sqlServer.TablePrefix = "QRTZ_";
                    });
                    s.UseJsonSerializer();
                    s.UseClustering(c =>
                    {
                        c.CheckinMisfireThreshold = TimeSpan.FromSeconds(20);
                        c.CheckinInterval = TimeSpan.FromSeconds(10);
                    });
                });
            });
            
            services.AddTransient<IntegrationEventOutboxJob>();

            return services;
        }
    }
}