namespace SportsBet.Infrastructure.Configuration
{
    public static class HealthChecksConfiguration
    {
        public static IServiceCollection RegisterHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConfig = configuration.GetSection(nameof(SqlConnectionSettings)).Get<SqlConnectionSettings>();

            var massTransitConfig = configuration.GetSection(nameof(BusSettings)).Get<BusSettings>();

            services.AddHealthChecks()
                .AddSqlServer(
                    connectionString: sqlConfig.ConnectionString,
                    name: "database_health_check",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] { "database" })
				.AddRabbitMQ(
	                $"amqp://{massTransitConfig.Username}:{massTransitConfig.Password}@{massTransitConfig.HostName}/{massTransitConfig.VirtualHost}",
	                name: "rabbitmq_health_check",
	                failureStatus: HealthStatus.Unhealthy,
	                tags: new[] { "rabbitmq" }
                );

            return services;
        }

        private static Task WriteResponse(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json";

            var json = new JObject();
            json.Add("status", healthReport.Status.ToString());
            json.Add("totalDuration", healthReport.TotalDuration.ToString());

            var entriesJObject = new JObject();
            foreach (var entry in healthReport.Entries)
            {
                var entryJObject = new JObject();
                entryJObject.Add(new JProperty("status", entry.Value.Status.ToString()));
                entryJObject.Add(new JProperty("description", entry.Value.Description));
                entryJObject.Add(new JProperty("duration", entry.Value.Duration));
                entryJObject.Add(new JProperty("tags", JToken.FromObject(entry.Value.Tags)));
                entryJObject.Add(new JProperty("data", JToken.FromObject(entry.Value.Data)));

                var entryJProp = new JProperty(entry.Key, entryJObject);
                entriesJObject.Add(entryJProp);
            }
            json.Add("entries", entriesJObject);

            return context.Response.WriteAsync(Regex.Unescape(json.ToString(Formatting.Indented)));
        }
    }
}
