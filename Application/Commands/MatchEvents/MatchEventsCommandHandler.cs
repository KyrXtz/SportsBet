using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace SportsBet.Application.Commands.MatchesEvents;

public class MatchsEventsCommandHandler : IRequestHandler<MatchsEventsCommand, Result<Unit>>
{
    private readonly IEventCodesRetrievalService _specialEventCodesRetrievalService;
    private readonly IRepository<Match> _matchRepository;
    private readonly IRepository<Player> _playerRepository;
    private readonly IFeedQueuePublisher<CreateMatchsEventsCommand> _matchEventPublisher;
    private readonly IFeedQueuePublisher<UpdateMatchsEventsCommand> _matchUpdatedEventPublisher;
    private readonly IFeedQueuePublisher<CreateUpdateMatchsLineupsCommand> _matchLineupPublisher;
    private readonly IFeedQueuePublisher<CreateUpdateMatchsStatsCommand> _matchStatPublisher;

    public MatchsEventsCommandHandler(IMediatorHandler mediator,
        IEventCodesRetrievalService specialEventCodesRetrievalService,
        IRepository<Match> matchRepository,
        IRepository<Player> playerRepository,
        IFeedQueuePublisher<CreateMatchsEventsCommand> matchEventPublisher,
        IFeedQueuePublisher<UpdateMatchsEventsCommand> matchUpdatedEventPublisher,
        IFeedQueuePublisher<CreateUpdateMatchsLineupsCommand> matchLineupPublisher,
        IFeedQueuePublisher<CreateUpdateMatchsStatsCommand> matchStatPublisher)
    {
        _specialEventCodesRetrievalService = specialEventCodesRetrievalService;
        _matchRepository = matchRepository;
        _playerRepository = playerRepository;
        _matchEventPublisher = matchEventPublisher;
        _matchUpdatedEventPublisher = matchUpdatedEventPublisher;
        _matchLineupPublisher = matchLineupPublisher;
        _matchStatPublisher = matchStatPublisher;
    }
    public async Task<Result<Unit>> Handle(MatchsEventsCommand request, CancellationToken cancellationToken)
    {
        var eventList = request.Payload.EventList.Events.ToList();
        var matchIds = eventList.Select(e => e.MatchId);
        var matches = await _matchRepository.ListAsync(new GetMatchsByIdsSpecification(matchIds.ToArray()));

        eventList.RemoveAll(s =>
            !matches.Any(sp => sp.Id == s.MatchId));
        //|| matches.Where(sp => !sp.IsMapped()).Any(sp => sp.Id == s.MatchId)); //todo maybe add this, to have less junk in db

        var matchEventItems = eventList.Select(e => new MatchEventItem
        {
            MatchId = e.MatchId,
            EventCode = e.EventCode,
            EventCodeId = e.EventCodeId,
            EventNumber = e.EventNumber,
            MatchStateId = e.MatchStateId,
            Minute = e.Minute,
            Timestamp = e.Timestamp,
            Date = e.Date,
            ClockRunning = e.ClockRunning,
        });

        if (matchEventItems.Any())
        {
            var groupedMatchEventItems = matchEventItems.GroupBy(s => s.MatchId);
            foreach (var group in groupedMatchEventItems)
            {
                var singleMatchEventItems = group.AsEnumerable();
                var partitionedQueueMessageKey = group.Key;
                var command = new CreateMatchsEventsCommand(singleMatchEventItems);

                await _matchEventPublisher.Publish(partitionedQueueMessageKey, command);
            }
        }

        //Special Events
        var specialEventTypes = await _specialEventCodesRetrievalService.GetSpecialEventTypes();

        var matchEventUpdatedItems = eventList
            //todo add this, when we know exactly what codes are for the special events , and what particular fields we need to filter int the ToKeyValueDictionary method
            //until then, we write the WHOLE event 
            .Where(e => specialEventTypes.Select(s => s.CodeId).Contains(e.EventCodeId))
            .Select(e => new MatchEventUpdatedItem
            {
                MatchId = e.MatchId,
                EventNumber = e.EventNumber,
                SpecialEventValues = e.ToKeyValueDictionary(specialEventTypes.FirstOrDefault(s => s.CodeId == e.EventCodeId)?.SpecialEventFields ?? new List<string>()),
                EventReasonId = e.EventReasonId,
                EventReasonValue = e.EventReason,
                ClearedMatchEventNumbers = e.ClearsEventsIds.ToArray(),
                RelatedMatchEventNumbers = e.RelatedEventsIds.ToArray(),
            });

        if (matchEventUpdatedItems.Any())
        {
            var groupedMatchUpdatedEventItems = matchEventUpdatedItems.GroupBy(s => s.MatchId);
            foreach (var group in groupedMatchUpdatedEventItems)
            {
                var singleMatchUpdatedEventItems = group.AsEnumerable();
                var partitionedQueueMessageKey = group.Key;
                var command = new UpdateMatchsEventsCommand(singleMatchUpdatedEventItems);

                await _matchUpdatedEventPublisher.Publish(partitionedQueueMessageKey, command);
            }
        }

        //Lineups
        var playerIds = eventList
            .SelectMany(e => e.Lineups).SelectMany(l => l.LineupPlayers)
            .Select(lp => lp.PlayerId).Distinct().ToArray();

        var players = await _playerRepository.ListAsync(new GetPlayersByIdsSpecification(playerIds));

        var matchLineupItems = eventList
            .SelectMany(e =>
            {
                var match = matches.FirstOrDefault(sp => sp.Id == e.MatchId);

                return e.Lineups.SelectMany(l => l.LineupPlayers.Where(lp => players.Any(p => p.Id == lp.PlayerId)).Select(lp => new MatchLineupItem
                {
                    MatchId = e.MatchId,
                    SportId = match.SportId,
                    Type = l.SquadTypeId,
                    CompetitorId = l.CompetitorId,
                    PlayerId = lp.PlayerId,
                    IsHome = match.Competitors.HomeCompetitorId == l.CompetitorId
                }));
            });


        if (matchLineupItems.Any())
        {
            var groupedMatchLineupItems = matchLineupItems.GroupBy(s => s.MatchId);
            foreach (var group in groupedMatchLineupItems)
            {
                var singleMatchLineupItems = group.AsEnumerable();
                var partitionedQueueMessageKey = group.Key;
                var command = new CreateUpdateMatchsLineupsCommand(singleMatchLineupItems);

                await _matchLineupPublisher.Publish(partitionedQueueMessageKey, command);
            }
        }

        //Stats
        var statTypes = await _specialEventCodesRetrievalService.GetStatTypes();

        var matchStatItems = eventList
            .Where(e => statTypes.Select(s => s.CodeId).Contains(e.EventCodeId))
            .SelectMany(e =>
            {
                return e.StatisticsDict.Select(st => new MatchStatItem
                {
                    MatchId = e.MatchId,
                    EventId = e.EventCodeId,
                    CompetitorId = e.CompetitorId,
                    PlayerId = e.PlayerId,
                    Value = st.Value
                });
            });

        if (matchStatItems.Any())
        {
            var groupedMatchStatItems = matchStatItems.GroupBy(s => s.MatchId);
            foreach (var group in groupedMatchStatItems)
            {
                var singleMatchStatItems = group.AsEnumerable();
                var partitionedQueueMessageKey = group.Key;
                var command = new CreateUpdateMatchsStatsCommand(singleMatchStatItems);

                await _matchStatPublisher.Publish(partitionedQueueMessageKey, command);
            }
        }

        ////Achievements
        //var achievementTypes = await _specialEventCodesRetrievalService.GetAchievementTypes();
        //TODO call achievements service
        //move this logic to the FeedConsumer

        return Result<Unit>.Success(Unit.Value);
    }
}