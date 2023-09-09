namespace SportsBet.Metrics
{
	public static class AppMetricsNLog
	{
		private static IInfrastructureMetrics? _metrics;

		public static void Init(IInfrastructureMetrics metrics)
		{
			_metrics = metrics;
		}

		public static void RecordLogMethod(string logger, string level)
		{
			var constantLoggerName = logger.Split('-').FirstOrDefault() ?? "NoLoggerName";

            _metrics?.RecordLog(constantLoggerName, level);
        }
	}
}
