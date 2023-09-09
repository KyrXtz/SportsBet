namespace SportsBet.Infrastructure.Configuration;

public static class LoggingConfiguration
{
    public static IApplicationBuilder UseLoggingHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<LoggingMiddleware>();
    }
}