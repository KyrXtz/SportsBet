namespace SportsBet.Infrastructure.Decorators
{
    class HttpRepositoryMetricsDecorator : IHttpRepository
    {
        private readonly IHttpRepository _decorated;
        private readonly IInfrastructureMetrics _metrics;

        public HttpRepositoryMetricsDecorator(IHttpRepository decorated, IInfrastructureMetrics metrics)
        {
            _decorated = decorated;
            _metrics = metrics;
        }

        public async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var endpointPath = string.Join("/", endpoint.Split('/', StringSplitOptions.RemoveEmptyEntries).Take(2));
                var response = await _decorated.GetAsync<T>(endpoint, cancellationToken);
                _metrics.RecordHttpRequest((int)HttpStatusCode.OK, endpointPath, sw.ElapsedMilliseconds);
                return response;
            }
            catch (HttpRequestException ex)
            {
                _metrics.RecordErroredHttpRequest((int)(ex.StatusCode ?? HttpStatusCode.NotFound), typeof(T).Name, sw.ElapsedMilliseconds);
                return default;
            }
        }
    }
}
