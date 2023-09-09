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
            case CreateUpdateSportsTickersCommand sportsTickerEventCommand:
                await mediatorHandler.SendCommand<List<int>>(sportsTickerEventCommand, cancellationToken);
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
            case CreateSportsTickersEventsCommand sportsTickersEventCommand:
                await mediatorHandler.SendCommand<List<long>>(sportsTickersEventCommand, cancellationToken);
                break;
            case UpdateSportsTickersEventsCommand sportsTickersEventCommand:
                await mediatorHandler.SendCommand<List<long>>(sportsTickersEventCommand, cancellationToken);
                break;
            case CreateUpdateSportsTickersLineupsCommand sportsTickersLineupCommand:
                await mediatorHandler.SendCommand<List<int>>(sportsTickersLineupCommand, cancellationToken);
                break;
            case CreateUpdateSportsTickersStatsCommand sportsTickersStatsCommand:
                await mediatorHandler.SendCommand<List<int>>(sportsTickersStatsCommand, cancellationToken);
                break;
            default:
                _logger.LogError($"No case found for command {command.GetType().FullName} .");
                break;
        }                
    }
}