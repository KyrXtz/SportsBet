namespace SportsBet.Application.Behaviors
{
    class QueryMetricsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : QueryBase, IRequest<TResponse>
    {
        private readonly IApplicationMetrics _metrics;

        public QueryMetricsBehavior(IApplicationMetrics metrics)
        {
            _metrics = metrics;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                var response = await next();

                _metrics.RecordQuery(sw.ElapsedMilliseconds, request.GetType());
                return response;
            }
            catch (Exception)
            {
                _metrics.RecordErroredQuery(sw.ElapsedMilliseconds, request.GetType());
                throw;
            }
        }
    }
}