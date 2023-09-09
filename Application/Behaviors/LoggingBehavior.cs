namespace SportsBet.Application.Behaviors
{
    class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var req = JsonConvert.SerializeObject(request, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            _logger.LogInformation($"Handling command {typeof(TRequest).Name} with data : {req}");

            var response = await next();

            var resp = JsonConvert.SerializeObject(response, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
            _logger.LogInformation($"Command {typeof(TRequest).Name} handled with response: {resp}");

            return response;
        }
    }
}