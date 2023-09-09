var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
	var builder = WebApplication.CreateBuilder(args);

	// Add services to the container.

	builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

	builder.Logging.ClearProviders();
	builder.Host.UseNLog();

	builder.Services.AddControllers(x =>
	{
		x.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
	}).AddNewtonsoftJson(x =>
	{
		x.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects;
	}).AddXmlSerializerFormatters();

	builder.Services.AddDefaultServices();
	builder.Services.AddFluentValidationServices();
	builder.Services.AddHttpFactory();
	builder.Services.AddRabbitMq();
	builder.Services.RegisterAppMetrics();
	builder.Services.RegisterHealthChecks(builder.Configuration);
	builder.Services.ConfigUniqueIdGenerator();
	builder.Services.AddPartitionedQueue();

	builder.Services.AddApiVersioning(config =>
	{
		config.DefaultApiVersion = new ApiVersion(1, 0);
		config.AssumeDefaultVersionWhenUnspecified = true;
		config.ReportApiVersions = true;
	});

	builder.Services.AddVersionedApiExplorer(options =>
	{
		options.GroupNameFormat = "'v'VVV";
		options.SubstituteApiVersionInUrl = true;
	});

	builder.Services.AddQuartz();

	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen(options =>
	{
		options.SwaggerDoc("v1", new OpenApiInfo
		{
			Version = "v1",
			Title = "SportsBet Microservice",
			Description = "Integration with SportsBet Provider",
		});
	});

	builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
			builder.RegisterModule(new DefaultApplicationModule()));

	builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
			builder.RegisterModule(new DefaultInfrastructureModule()));

	builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
		builder.RegisterModule(new DefaultApiModule()));

	var app = builder.Build();

	// Configure the HTTP request pipeline.

	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

	//app.UseAuthorization();
	app.UseApplicationLifetime();
	app.UseLoggingHandling();
	app.UseErrorHandling();
	app.UseRouting();

	app.UseAppMetricsPrometheus(new AppMetricsPrometheusSettings { UseSystemUsageCollector = true });

	app.UseAppMetricsApi();

	app.UseEndpoints(endpoints =>
	{
		endpoints.MapControllers();

		endpoints.MapGet("/", async context =>
		{
			await context.Response.WriteAsync("SportsBet Microservice");
		});

	});

	app.Run();
}
catch (Exception exception)
{
	logger.Error(exception, "Stopped program because of exception");
	throw;
}
finally
{
	LogManager.Shutdown();
}
