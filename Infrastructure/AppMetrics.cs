using Unit = App.Metrics.Unit;

namespace SportsBet.Metrics
{
    public interface IInfrastructureMetrics
    {
        void RecordHttpRequest(int statusCode, string path, long durationMilliseconds);
        void RecordErroredHttpRequest(int statusCode, string path, long durationMilliseconds);
        void RecordApiRequest(int statusCode, string path, long durationMilliseconds);
        void RecordErroredApiRequest(int statusCode, string path, long durationMilliseconds);
        void RecordDatabaseTime(long milliseconds, string action, Type type);
        void RecordErroredDatabaseTime(long milliseconds, string action, Type type);
        void RecordJob(long milliseconds, string jobName);
        void RecordErroredJob(long milliseconds, string jobName);
        void RecordLog(string loggerName, string level);
        void RecordDatabaseSize(string name, long count);
        void RecordHealthCheck(string type, int healthStatus);
        void RecordConsumeMessageTime(long milliseconds, string messageName);
        void RecordErroredConsumeMessage(long milliseconds, string messageName);
        void RecordExternalCall(long milliseconds, string type);
        void RecordErroredExternalCall(long milliseconds, string type);
        void RecordPublishedQueueItem(long milliseconds, Type itemType, string queue);
        void RecordErroredQueueItem(long milliseconds, Type itemType, string queue);
        void RecordVolume(int count, string sysname);
        void RecordErroredVolume(int count, string sysname);
        void RecordDuration(long milliseconds, string sysname);
        void RecordErroredDuration(long milliseconds, string sysname);

    }
    public class InfrastructureMetrics : IInfrastructureMetrics
    {
        private readonly App.Metrics.IMetrics _metrics;

        public InfrastructureMetrics(App.Metrics.IMetrics metrics)
        {
            _metrics = metrics;
        }

        private readonly static HistogramOptions _httpRequestTime = new HistogramOptions
        {
            Name = "HttpRequest",
            MeasurementUnit = App.Metrics.Unit.Items,
            ResetOnReporting = true
        };
        private readonly static HistogramOptions _apiRequestsTime = new HistogramOptions
        {
            Name = "HttpRequest",
            MeasurementUnit = App.Metrics.Unit.Items,
            ResetOnReporting = true
        };
        private readonly static HistogramOptions _databaseTime = new HistogramOptions
        {
            Name = "DatabaseTime",
            MeasurementUnit = App.Metrics.Unit.Items,
            ResetOnReporting = true
        };
        private readonly static HistogramOptions _jobsTime = new HistogramOptions
        {
            Name = "JobsTime",
            MeasurementUnit = App.Metrics.Unit.Items,
            ResetOnReporting = true
        };
        private readonly static CounterOptions _logs = new CounterOptions
        {
            Name = "Logs",
            MeasurementUnit = App.Metrics.Unit.Items,
            ResetOnReporting = true
        };
        private readonly static GaugeOptions _databaseSize = new GaugeOptions
        {
            Name = "DatabaseSize",
            MeasurementUnit = App.Metrics.Unit.Items,
            ResetOnReporting = false,
        };
        private readonly static GaugeOptions _healthchecks = new GaugeOptions
        {
            Name = "Service_Uptime",
            MeasurementUnit = Unit.Items,
            ResetOnReporting = false,
        };
        private readonly static HistogramOptions _messageConsumeTime = new HistogramOptions
        {
            Name = "MessageConsumeTime",
            MeasurementUnit = Unit.Items,
            ResetOnReporting = true
        };
        private static HistogramOptions _externalCallsTime => new HistogramOptions
        {
            Name = "ExternalCallsTime",
            MeasurementUnit = Unit.Items,
            ResetOnReporting = true,
        };
        private static readonly HistogramOptions _queueItemsProcessed = new HistogramOptions
        {
            Name = "QueueItemsProcessed",
            MeasurementUnit = Unit.Items,
            ResetOnReporting = true,
        };
        private static readonly CounterOptions _volumes = new CounterOptions
        {
            Name = "Volumes",
            MeasurementUnit = Unit.Items,
            ResetOnReporting = true,
        };
        private static readonly HistogramOptions _durations = new HistogramOptions
        {
            Name = "Durations",
            MeasurementUnit = Unit.Items,
            ResetOnReporting = true,
        };

        public void RecordHttpRequest(int statusCode, string path, long durationMilliseconds)
            => _metrics.Measure.Histogram.Update(_httpRequestTime, new App.Metrics.MetricTags(new[] { "HttpStatusCode", "path" }, new[] { statusCode.ToString(), path }), durationMilliseconds);
        public void RecordErroredHttpRequest(int statusCode, string path, long durationMilliseconds)
            => _metrics.Measure.Histogram.Update(_httpRequestTime, new App.Metrics.MetricTags(new[] { "HttpStatusCode", "path" }, new[] { statusCode.ToString(), path }), durationMilliseconds);
        public void RecordApiRequest(int statusCode, string path, long durationMilliseconds)
            => _metrics.Measure.Histogram.Update(_apiRequestsTime, new App.Metrics.MetricTags(new[] { "HttpStatusCode", "path" }, new[] { statusCode.ToString(), path }), durationMilliseconds);
        public void RecordErroredApiRequest(int statusCode, string path, long durationMilliseconds)
            => _metrics.Measure.Histogram.Update(_apiRequestsTime, new App.Metrics.MetricTags(new[] { "HttpStatusCode", "path" }, new[] { statusCode.ToString(), path }), durationMilliseconds);
        public void RecordDatabaseTime(long milliseconds, string action, Type type)
            => _metrics.Measure.Histogram.Update(_databaseTime, new App.Metrics.MetricTags(new[] { "status", "action", "type" }, new[] { "success", action, type.Name }), milliseconds);
        public void RecordErroredDatabaseTime(long milliseconds, string action, Type type)
            => _metrics.Measure.Histogram.Update(_databaseTime, new App.Metrics.MetricTags(new[] { "status", "action", "type" }, new[] { "failed", action, type.Name }), milliseconds);
        public void RecordJob(long milliseconds, string jobName)
            => _metrics.Measure.Histogram.Update(_jobsTime, new App.Metrics.MetricTags(new[] { "status", "name" }, new[] { "success", jobName }), milliseconds);
        public void RecordErroredJob(long milliseconds, string jobName)
            => _metrics.Measure.Histogram.Update(_jobsTime, new App.Metrics.MetricTags(new[] { "status", "name" }, new[] { "failed", jobName }), milliseconds);
        public void RecordLog(string loggerName, string level)
            => _metrics.Measure.Counter.Increment(_logs, new App.Metrics.MetricTags(new[] { "logger", "level" }, new[] { loggerName, level }));
        public void RecordDatabaseSize(string name, long count)
            => _metrics.Measure.Gauge.SetValue(_databaseSize, new App.Metrics.MetricTags(new[] { "name" }, new[] { name }), count);
        public void RecordHealthCheck(string type, int healthStatus)
            => _metrics.Measure.Gauge.SetValue(_healthchecks, new MetricTags(new[] { "type" }, new[] { type }), healthStatus);
        public void RecordConsumeMessageTime(long milliseconds, string messageName)
            => _metrics.Measure.Histogram.Update(_messageConsumeTime, new MetricTags(new[] { "status", "type" }, new[] { "success", messageName }), milliseconds);
        public void RecordErroredConsumeMessage(long milliseconds, string messageName)
            => _metrics.Measure.Histogram.Update(_messageConsumeTime, new MetricTags(new[] { "status", "type" }, new[] { "failed", messageName }), milliseconds);
        public void RecordExternalCall(long milliseconds, string type)
                => _metrics.Measure.Histogram.Update(_externalCallsTime, new MetricTags(new[] { "status", "type" }, new[] { "success", type }), milliseconds);
        public void RecordErroredExternalCall(long milliseconds, string type)
            => _metrics.Measure.Histogram.Update(_externalCallsTime, new MetricTags(new[] { "status", "type" }, new[] { "failed", type }), milliseconds);
        public void RecordPublishedQueueItem(long milliseconds, Type itemType, string queue)
        => _metrics.Measure.Histogram.Update(_queueItemsProcessed, new MetricTags(new[] { "action", "type", "queue" }, new[] { "published", itemType.Name, queue }), milliseconds);
        public void RecordErroredQueueItem(long milliseconds, Type itemType, string queue)
            => _metrics.Measure.Histogram.Update(_queueItemsProcessed, new MetricTags(new[] { "action", "type", "queue" }, new[] { "errored", itemType.Name, queue }), milliseconds);
        public void RecordVolume(int count, string sysname)
            => _metrics.Measure.Counter.Increment(_volumes, new MetricTags(new[] { "sysname", "status" }, new[] { sysname, "success" }), count);
        public void RecordErroredVolume(int count, string sysname)
            => _metrics.Measure.Counter.Increment(_volumes, new MetricTags(new[] { "sysname", "status" }, new[] { sysname, "errored" }), count);
        public void RecordDuration(long milliseconds, string sysname)
            => _metrics.Measure.Histogram.Update(_durations, new MetricTags(new[] { "sysname", "status" }, new[] { sysname, "success" }), milliseconds);
        public void RecordErroredDuration(long milliseconds, string sysname)
            => _metrics.Measure.Histogram.Update(_durations, new MetricTags(new[] { "sysname", "status" }, new[] { sysname, "errored" }), milliseconds);
    }
}
