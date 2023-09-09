namespace SportsBet.Infrastructure.HostedServices
{
	class DatabaseSizeCollectorHostedService : IHostedService
	{
		private readonly IConfiguration _configuration;
		private readonly IInfrastructureMetrics _metrics;
		private readonly ILogger<DatabaseSizeCollectorHostedService> _logger;
		private Timer? _timer;

		public DatabaseSizeCollectorHostedService(IConfiguration configuration,
			IInfrastructureMetrics metrics,
			ILogger<DatabaseSizeCollectorHostedService> logger)
		{
			_configuration = configuration;
			_metrics = metrics;
			_logger = logger;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_timer = new Timer(CollectData, null, 3000, 30000);
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_timer?.Change(-1, -1);
			_timer?.Dispose();
			return Task.CompletedTask;
		}

		private void CollectData(object? state)
		{
			try
			{
                using (var connection = new SqlConnection(_configuration.GetSection(nameof(SqlConnectionSettings)).Get<SqlConnectionSettings>().ConnectionString))
                {
					connection.Open();

					var sql = @"
						SELECT
							  QUOTENAME(SCHEMA_NAME(sOBJ.schema_id)) + '.' + QUOTENAME(sOBJ.name) AS [TableName]
							  , SUM(sPTN.Rows) AS [RowCount]
						FROM 
							  sys.objects AS sOBJ
							  INNER JOIN sys.partitions AS sPTN
									ON sOBJ.object_id = sPTN.object_id
						WHERE
							  sOBJ.type = 'U'
							  AND sOBJ.is_ms_shipped = 0x0
							  AND index_id < 2 -- 0:Heap, 1:Clustered
						GROUP BY 
							  sOBJ.schema_id
							  , sOBJ.name
						ORDER BY [TableName]
					";

					using (var command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								var tableName = reader.GetString(0);
								var rownCount = reader.GetInt64(1);
								_metrics.RecordDatabaseSize(tableName, rownCount);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while collection DBSize", null);
			}
		}
	}
}
