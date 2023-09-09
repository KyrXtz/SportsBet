namespace SportsBet.Infrastructure.Jobs
{
    class JobFactory : IJobFactory
    {
        protected readonly IServiceProvider _container;

        public JobFactory(IServiceProvider container)
        {
            _container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var job = (IJob)_container.GetService(bundle.JobDetail.JobType)!;
            var infrastructureMetrics = _container.GetService<IInfrastructureMetrics>()!;
            return new JobMetricsDecorator(job, infrastructureMetrics);
        }

        public void ReturnJob(IJob job) { }
    }
}

