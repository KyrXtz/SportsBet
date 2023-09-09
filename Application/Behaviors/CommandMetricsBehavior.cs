namespace SportsBet.Application.Behaviors
{
    class CommandMetricsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : CommandBase, IRequest<TResponse>
    {
        private readonly IApplicationMetrics _metrics;

        public CommandMetricsBehavior(IApplicationMetrics metrics)
        {
            _metrics = metrics;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                var response = await next();

                _metrics.RecordCommand(sw.ElapsedMilliseconds, request.GetType());

                return response;
            }
            catch (Exception)
            {
                _metrics.RecordErroredCommand(sw.ElapsedMilliseconds, request.GetType());
                throw;
            }
        }
    }
}

