namespace SportsBet.Application.Behaviors;

class ErroredCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IErroredCommand
{
    private readonly IRepository<ErroredCommandLog> _erroredCommandLogRepository;
    private readonly ILogger<TRequest> _logger;

    public ErroredCommandBehavior(IRepository<ErroredCommandLog> erroredCommandLogRepository, ILogger<TRequest> logger)
    {
        _erroredCommandLogRepository = erroredCommandLogRepository;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var policy = Policy.Handle<Exception>()
            .WaitAndRetryAsync(retryCount: 2,
            sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(1),
            onRetry: (exception, timeSpan, retryAttempt, context) =>
            {               
                _logger.LogWarning(exception, $"{request.GetType().FullName!} threw an exception and will be retried. Retry attempt: {retryAttempt}. Exception message : {exception.Message}");
            });

        var policyRes = await policy.ExecuteAndCaptureAsync(async () => await next());


        if (policyRes.Outcome != OutcomeType.Successful)
        {
            _logger.LogError(policyRes.FinalException, $"{request.GetType().FullName!} threw an exception. Exception message : {policyRes.FinalException.Message}");

            var data = JsonConvert.SerializeObject(request, request.GetType(), Formatting.Indented, null);

            var newEventLog = ErroredCommandLog.Create(command: request.GetType().FullName!, data: data, message: policyRes.FinalException.Message);
            await _erroredCommandLogRepository.AddAsync(newEventLog, cancellationToken);
        }

        return policyRes.Result;
    }
}