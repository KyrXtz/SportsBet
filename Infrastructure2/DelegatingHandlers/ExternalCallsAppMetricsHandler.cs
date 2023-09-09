namespace SportsBet.Infrastructure.DelegatingHandlers
{
    class ExternalCallsAppMetricsHandler : DelegatingHandler
    {
        private readonly IInfrastructureMetrics _metrics;

        public ExternalCallsAppMetricsHandler(IInfrastructureMetrics metrics)
        {
            _metrics = metrics;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var route = GetRoute(request.RequestUri!.ToString());
            var sw = Stopwatch.StartNew();
            try
            {
                var result = await base.SendAsync(request, cancellationToken);
                _metrics.RecordExternalCall(sw.ElapsedMilliseconds, route);
            
                return result;
            }
            catch
            {
                _metrics.RecordErroredExternalCall(sw.ElapsedMilliseconds, route);
                throw;
            }
        }

        private string GetRoute(string uri)
        {
            try
            {
                var routeParts = uri.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var serviceName = routeParts[1].Split('-')[0].Split('.')[0];
                var clientName = routeParts[3];
                var methodName = int.TryParse(routeParts[routeParts.Length - 1], out _) ? "/" : routeParts[routeParts.Length - 1].Split('?')[0];

                return $"{serviceName} - {clientName} - {methodName}";
            }
            catch
            {
                return uri;
            }

        }
    }
}
