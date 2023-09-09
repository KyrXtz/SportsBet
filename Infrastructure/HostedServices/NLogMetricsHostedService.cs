namespace SportsBet.Infrastructure.HostedServices
{
	class NLogMetricsHostedService : IHostedService
	{
		private readonly IInfrastructureMetrics _metrics;

		public NLogMetricsHostedService(IInfrastructureMetrics metrics)
		{
			_metrics = metrics;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			AppMetricsNLog.Init(_metrics);

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
