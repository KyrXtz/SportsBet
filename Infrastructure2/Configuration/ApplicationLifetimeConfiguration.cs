namespace SportsBet.Infrastructure.Configuration
{
    public static class ApplicationLifetimeConfiguration
    {
        private const string loggerName = "Core";

        public static IApplicationBuilder UseApplicationLifetime(this IApplicationBuilder app)
        {
            var logger = app.ApplicationServices.GetService<ILoggerFactory>().CreateLogger(loggerName);
            var appLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            var hostingEnvironment = app.ApplicationServices.GetService<IWebHostEnvironment>();
            var appName = hostingEnvironment?.ApplicationName;

            appLifetime?.ApplicationStarted.Register(() => { logger.LogInformation($"{appName} started."); });
            appLifetime?.ApplicationStopping.Register(() => { logger.LogWarning($"{appName} stopping."); });
            appLifetime?.ApplicationStopped.Register(() => { logger.LogWarning($"{appName} stopped."); });

            return app;
        }
    }
}

