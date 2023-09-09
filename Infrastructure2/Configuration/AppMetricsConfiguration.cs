namespace SportsBet.Infrastructure.Configuration;

public static class AppMetricsConfiguration
{
	public static IServiceCollection RegisterAppMetrics(this IServiceCollection services)
	{			
		var metrics = App.Metrics.AppMetrics.CreateDefaultBuilder()
			.Configuration.Configure(
				options =>
				{
					options.Enabled = true;
					options.ReportingEnabled = true;
				})
			.Build();

		services.AddMetrics(metrics);	
		return services;
	}
		
	public static IApplicationBuilder UseAppMetricsApi(this IApplicationBuilder app)
	{
		return app.UseMiddleware<ApiRequestsMetricsMiddleware>();
	}
}