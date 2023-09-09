namespace SportsBet.Infrastructure.HostedServices
{
    public class HealthChecksHostedService : BackgroundService
    {
        private readonly IInfrastructureMetrics _infrastructureMetrics;
        private readonly HealthCheckService _healthCheckService;
        private readonly GeneralSettings _generalSettings;

        public HealthChecksHostedService(IInfrastructureMetrics infrastructureMetrics,
            HealthCheckService healthCheckService,
            IOptions<GeneralSettings> generalSettings)
        {
            _infrastructureMetrics = infrastructureMetrics;
            _healthCheckService = healthCheckService;
            _generalSettings = generalSettings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(_generalSettings.HealthChecksDelay));
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                var chechResult = await _healthCheckService.CheckHealthAsync(stoppingToken);
                foreach (var item in chechResult.Entries)
                {
                    var healthStatus = item.Value.Status switch
                    {
                        HealthStatus.Healthy => 1,
                        HealthStatus.Degraded => 2,
                        HealthStatus.Unhealthy => 0
                    };

                    _infrastructureMetrics.RecordHealthCheck(item.Key, healthStatus);
                }
            }
        }
    }
}

