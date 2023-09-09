namespace SportsBet.Application.Commands.PlayerInformation;

using Competitor = Domain.Aggregates.Competitors.Competitor;
public class PlayerInformationCommandHandler : IRequestHandler<PlayerInformationCommand, Result<Unit>>
{
    private readonly IRepository<Player> _playerRepository;
    private readonly IRepository<Competitor> _competitorRepository;
    private readonly IFeedQueuePublisher<CreateUpdatePlayersCommand> _playersPublisher;
    private readonly IFeedQueuePublisher<CreateUpdateSquadsCommand> _squadsPublisher;

    public PlayerInformationCommandHandler(IMediatorHandler mediator,
        IRepository<Player> playerRepository,
        IRepository<Competitor> competitorRepository,
        IFeedQueuePublisher<CreateUpdatePlayersCommand> playersPublisher,
        IFeedQueuePublisher<CreateUpdateSquadsCommand> squadsPublisher)
    {
        _playerRepository = playerRepository;
        _competitorRepository = competitorRepository;
        _playersPublisher = playersPublisher;
        _squadsPublisher = squadsPublisher;
    }
    public async Task<Result<Unit>> Handle(PlayerInformationCommand request, CancellationToken cancellationToken)
    {
        var playerList = request.Payload.PlayerList.Players.ToList();
        var playerIds = playerList.Select(e => e.Id);
        var players = await _playerRepository.ListAsync(new GetPlayersByIdsSpecification(playerIds.ToArray()));

        var playerItems = playerList.Select(e => new PlayerItem
        {
            Id = e.Id,
            Name = e.Name,
            Position = e.PositionId,
            ProviderCountryId = e.CountryId
        });

        if (playerItems.Any())
        {
            var groupedPlayerItems = playerItems.GroupBy(s => s.Id);
            foreach (var group in groupedPlayerItems)
            {
                var singlePlayerItems = group.AsEnumerable();
                var partitionedQueueMessageKey = group.Key;
                var command = new CreateUpdatePlayersCommand(singlePlayerItems);

                await _playersPublisher.Publish(partitionedQueueMessageKey, command);
            }
        }

        var competitorIds = playerList.SelectMany(p => p.Lineup).Select(l => l.CompetitorId).ToArray();
        var competitors = await _competitorRepository.ListAsync(new GetCompetitorsByIdsSpecification(competitorIds));

        playerList.RemoveAll(p =>
            !competitors.Any(c => p.Lineup.Any(l => l.CompetitorId == c.Id)));

        var squadItems = playerList.SelectMany(p =>
        {
            return p.Lineup.Select(l => new SquadItem
            {
                CompetitorId = l.CompetitorId,
                PlayerId = p.Id,
                Rating = l.RatingId,
                JerseyNumber = l.JerseyNumber
            });
        });

        if (squadItems.Any())
        {
            var groupedSquadItems = squadItems.GroupBy(s => new { s.CompetitorId, s.PlayerId });
            foreach (var group in groupedSquadItems)
            {
                var singleSquadItems = group.AsEnumerable();
                var partitionedQueueMessageKey = long.Parse($"{group.Key.CompetitorId}{group.Key.PlayerId}"); //todo create better key ?
                var command = new CreateUpdateSquadsCommand(singleSquadItems);

                await _squadsPublisher.Publish(partitionedQueueMessageKey, command);
            }
        }

        return Result<Unit>.Success(Unit.Value);
    }
}