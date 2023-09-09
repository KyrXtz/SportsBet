namespace SportsBet.Infrastructure.Jobs
{
    [DisallowConcurrentExecution]
    public abstract class BaseJob<T> : IJob
    {
        private readonly IServiceProvider _serviceProvider;

        protected readonly ILogger<T> Logger;
        protected IMediatorHandler MediatorHandler;


        protected BaseJob(ILogger<T> logger,
            IServiceProvider serviceProvider)
        {
            Logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                using var serviceScope = _serviceProvider.CreateScope();
                MediatorHandler = serviceScope.ServiceProvider.GetService<IMediatorHandler>()!;

                await ExecuteJob(context);

            }
            catch (Exception ex)
            {
                var jex = new JobExecutionException(ex, false);

                throw jex; 
            }
        }

        public abstract Task ExecuteJob(IJobExecutionContext context);

        public bool IsValidExpressionCronExpression(string exp)
        {
            return !string.IsNullOrWhiteSpace(exp) && CronExpression.IsValidExpression(exp);
        }

        public static bool CronExpressionIsValid(string exp)
        {
            if (string.IsNullOrWhiteSpace(exp))
                return false;

            CronExpression.ValidateExpression(exp);

            return CronExpression.IsValidExpression(exp);
        }
    }


}