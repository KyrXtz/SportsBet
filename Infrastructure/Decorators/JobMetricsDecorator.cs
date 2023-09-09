namespace SportsBet.Infrastructure.Decorators
{
    class JobMetricsDecorator : IJob
    {
        private readonly IJob _decorated;
        private readonly IInfrastructureMetrics _metrics;

        public JobMetricsDecorator(IJob decorated,
            IInfrastructureMetrics metrics)
        {
            _decorated = decorated;
            _metrics = metrics;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var jobName = context.JobDetail.Key.Name;
            var sw = Stopwatch.StartNew();

            try
            {
                await _decorated.Execute(context);

                _metrics.RecordJob(sw.ElapsedMilliseconds, jobName);
            }
            catch
            {
                _metrics.RecordErroredJob(sw.ElapsedMilliseconds, jobName);
                throw;
            }
        }
    }
}
