namespace SportsBet.Infrastructure.Configuration
{
    public static class HealthChecksConfiguration
    {
        public static IServiceCollection RegisterHealthChecks(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            //services.AddHealthChecks()
            //    .AddLivenessHealthChecks(configuration!);

            
            var sqlConfig = configuration.GetSection(nameof(SqlConnectionSettings)).Get<SqlConnectionSettings>();
            var sqlConfiguration = new SqlConfiguration()
            {
                ConnectionString = sqlConfig.ConnectionString,
                DataSource = sqlConfig.DataSource,
                InitialCatalog = sqlConfig.InitialCatalog,
                Username = sqlConfig.Username,
                Password = sqlConfig.Password

            };

            var massTransitConfig = configuration.GetSection(nameof(BusSettings)).Get<BusSettings>();
            var rabbitMqOptions = new Common.HealthChecks.RabbitMQ.Configuration.RabbitMqConfiguration()
            {
                HostName = massTransitConfig.HostName,
                VirtualHost = massTransitConfig.VirtualHost,
                Username = massTransitConfig.Username,
                Password = massTransitConfig.Password
            };

            services.AddHealthChecksCustom()
                .AddCheckSql(name: "database_health_check", sqlConfiguration: sqlConfiguration, HealthCheckPriority.Critical, tags: new[] { "database" })
                .AddCheckRabbitMq(name: "rabbitmq_health_check", rabbitMqConfiguration: rabbitMqOptions, HealthCheckPriority.Critical, tags: new[] { "rabbitmq" });

            return services;
        }

        public static void MapCustomHealthChecks(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecksCustom();

            //endpoints.MapHealthChecks("/healthz/live",
            //    new HealthCheckOptions
            //    {
            //        Predicate = healthCheck => healthCheck.Tags.Contains("live") || healthCheck.Tags.Contains("masstransit"),
            //        AllowCachingResponses = false,
            //        ResponseWriter = WriteResponse,
            //        ResultStatusCodes =
            //        {
            //            [HealthStatus.Healthy] = StatusCodes.Status200OK,
            //            [HealthStatus.Degraded] = StatusCodes.Status200OK,
            //            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
            //        }
            //    });
        }

        //private static IHealthChecksBuilder AddLivenessHealthChecks(this IHealthChecksBuilder builder,
        //    IConfiguration configuration)
        //{
        //    var dbConnectionString = configuration.GetSection(nameof(SqlConnectionSettings)).Get<SqlConnectionSettings>().GetConnectionString();
        //    //var redisConnectionString = configuration.GetConnectionString("Redis");

        //    builder.AddSqlServer(connectionString: dbConnectionString,
        //        healthQuery: "SELECT 1;",
        //        name: "Database-SportsBet",
        //        failureStatus: HealthStatus.Unhealthy,
        //        tags: new[] { "live", "database-SportsBet" });

        //    return builder;
        //}

        //private static Task WriteResponse(HttpContext context, HealthReport healthReport)
        //{
        //    context.Response.ContentType = "application/json";

        //    var json = new JObject();

        //    json.Add("status", healthReport.Status.ToString());
        //    json.Add("totalDuration", healthReport.TotalDuration.ToString());

        //    var entriesJObject = new JObject();
        //    foreach (var entry in healthReport.Entries)
        //    {
        //        var entryJObject = new JObject();
        //        entryJObject.Add(new JProperty("status", entry.Value.Status.ToString()));
        //        entryJObject.Add(new JProperty("description", entry.Value.Description));
        //        entryJObject.Add(new JProperty("duration", entry.Value.Duration));
        //        entryJObject.Add(new JProperty("tags", JToken.FromObject(entry.Value.Tags)));
        //        entryJObject.Add(new JProperty("data", JToken.FromObject(entry.Value.Data)));

        //        var entryJProp = new JProperty(entry.Key, entryJObject);
        //        entriesJObject.Add(entryJProp);
        //    }
        //    json.Add("entries", entriesJObject);

        //    return context.Response.WriteAsync(Regex.Unescape(json.ToString(Formatting.Indented)));
        //}
    }
}

