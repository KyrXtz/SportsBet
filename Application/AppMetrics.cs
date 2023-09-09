namespace SportsBet.Metrics
{
	public interface IApplicationMetrics
	{
		void RecordCommand(long milliseconds, Type commandType);
		void RecordErroredCommand(long milliseconds, Type commandType);
		void RecordQuery(long milliseconds, Type commandType);
		void RecordErroredQuery(long milliseconds, Type commandType);
	}
	public class ApplicationMetrics : IApplicationMetrics
	{
		private readonly App.Metrics.IMetrics _metrics;

		public ApplicationMetrics(App.Metrics.IMetrics metrics)
		{
			_metrics = metrics;
		}

		private readonly static HistogramOptions _commandsTime = new HistogramOptions
		{
			Name = "CommandsTime",
			MeasurementUnit = App.Metrics.Unit.Items,
			ResetOnReporting = true
		};
		private readonly static HistogramOptions _queriesTime = new HistogramOptions
		{
			Name = "QueriesTime",
			MeasurementUnit = App.Metrics.Unit.Items,
			ResetOnReporting = true
		};

		public void RecordCommand(long milliseconds, Type commandType)
			=> _metrics.Measure.Histogram.Update(_commandsTime, new App.Metrics.MetricTags(new[] { "status", "type" }, new[] { "success", commandType.Name }), milliseconds);
		public void RecordErroredCommand(long milliseconds, Type commandType)
			=> _metrics.Measure.Histogram.Update(_commandsTime, new App.Metrics.MetricTags(new[] { "status", "type" }, new[] { "failed", commandType.Name }), milliseconds);
		public void RecordQuery(long milliseconds, Type commandType)
					=> _metrics.Measure.Histogram.Update(_queriesTime, new App.Metrics.MetricTags(new[] { "status", "type" }, new[] { "success", commandType.Name }), milliseconds);
		public void RecordErroredQuery(long milliseconds, Type commandType)
			=> _metrics.Measure.Histogram.Update(_queriesTime, new App.Metrics.MetricTags(new[] { "status", "type" }, new[] { "failed", commandType.Name }), milliseconds);
	}
}
