using Unit = MediatR.Unit;

namespace SportsBet.Infrastructure.Jobs
{
    public class IntegrationEventOutboxJob : BaseJob<IntegrationEventOutboxJob>
    {
        public IntegrationEventOutboxJob(ILogger<IntegrationEventOutboxJob> logger,
            IServiceProvider serviceProvider) : base(logger, serviceProvider)
        {
        }

        public override async Task ExecuteJob(IJobExecutionContext context)
        {
            await MediatorHandler.SendCommand<Unit>(new IntegrationEventOutboxJobCommand(), context.CancellationToken);
        }
    }
}

