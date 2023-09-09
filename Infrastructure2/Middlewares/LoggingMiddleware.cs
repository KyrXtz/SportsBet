namespace SportsBet.Infrastructure.Middlewares;

public sealed class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = await ReadBodyFromRequest(context.Request);

        if(!string.IsNullOrEmpty(request))
            _logger.LogInformation(request);
        
        await _next(context);
    }
    
    private async Task<string> ReadBodyFromRequest(HttpRequest request)
    {
        request.EnableBuffering();
        using var streamReader = new StreamReader(request.Body, leaveOpen: true);
        var requestBody = await streamReader.ReadToEndAsync();
        request.Body.Position = 0;
        return requestBody;
    }
}