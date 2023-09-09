namespace SportsBet.Infrastructure.Configuration
{
    public static class ErrorHandlingConfiguration
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}

