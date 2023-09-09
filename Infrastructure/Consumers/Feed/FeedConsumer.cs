namespace SportsBet.Infrastructure.Consumers.Feed;
class FeedConsumer : IPartitionedQueueConsumer
{
    private readonly IServiceScopeFactory _serviceProviderScopeFactory;
    private readonly ISerializationService _serializationService;
    private readonly ILogger<FeedConsumer> _logger;

    public FeedConsumer(IServiceScopeFactory serviceProviderScopeFactory, ISerializationService serializationService, ILogger<FeedConsumer> logger)
    {
        _serviceProviderScopeFactory = serviceProviderScopeFactory;
        _serializationService = serializationService;
        _logger = logger;
    }

    public async Task Consume(byte[] message, CancellationToken cancellationToken)
    {
        using var scope = _serviceProviderScopeFactory.CreateScope();

        var mediatorHandler = scope.ServiceProvider.GetService<IMediatorHandler>()!;

        var command = _serializationService.Deserialize<CommandBase>(message);
        switch (command)
        {
            case CreateUpdateMatchsCommand matchEventCommand:
                await mediatorHandler.SendCommand<List<int>>(matchEventCommand, cancellationToken);
                break;
            case CreateUpdateSeriesCommand seriesCommand:
                await mediatorHandler.SendCommand<List<long>>(seriesCommand, cancellationToken);
                break;
            case CreateUpdatePlayersCommand playerCommand:
                await mediatorHandler.SendCommand<List<int>>(playerCommand, cancellationToken);
                break;
            case CreateUpdateSquadsCommand squadCommand:
                await mediatorHandler.SendCommand<List<long>>(squadCommand, cancellationToken);
                break;
            case CreateMatchsEventsCommand matchsEventCommand:
                await mediatorHandler.SendCommand<List<long>>(matchsEventCommand, cancellationToken);
                break;
            case UpdateMatchsEventsCommand matchsEventCommand:
                await mediatorHandler.SendCommand<List<long>>(matchsEventCommand, cancellationToken);
                break;
            case CreateUpdateMatchsLineupsCommand matchsLineupCommand:
                await mediatorHandler.SendCommand<List<int>>(matchsLineupCommand, cancellationToken);
                break;
            case CreateUpdateMatchsStatsCommand matchsStatsCommand:
                await mediatorHandler.SendCommand<List<int>>(matchsStatsCommand, cancellationToken);
                break;
            default:
                _logger.LogError($"No case found for command {command.GetType().FullName} .");
                break;
        }                
    }
}