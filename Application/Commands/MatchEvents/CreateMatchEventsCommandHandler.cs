namespace SportsBet.Application.Commands.MatchesEvents;

internal class CreateMatchsEventsCommandHandler : IRequestHandler<CreateMatchsEventsCommand, Result<List<long>>>
{
    private readonly IRepository<MatchEvent> _repository;

    public CreateMatchsEventsCommandHandler(IRepository<MatchEvent> repository)
    {
        _repository = repository;
    }
    public async Task<Result<List<long>>> Handle(CreateMatchsEventsCommand request, CancellationToken cancellationToken)
    {
        var matchIds = request.MatchEvents.Select(p => p.MatchId).ToArray();
        var existingMatchsEvents = await _repository.ListAsync(new GetMatchsEventsByMatchIdSpecification(matchIds));

        var newMatchsEvents = new List<MatchEvent>();

        foreach (var matchEvent in request.MatchEvents)
        {
            var existingMatchEvent = existingMatchsEvents.FirstOrDefault(e => e.MatchId == matchEvent.MatchId 
                && e.Info.EventNumber == matchEvent.EventNumber);

            if (existingMatchEvent != null) continue; //todo add log ?              

            newMatchsEvents.Add(MatchEvent.Create(matchEvent.EventCodeId,
                matchEvent.EventNumber,
                matchEvent.EventCode,
                MatchState.FromValue(matchEvent.MatchStateId),
                matchEvent.Minute,
                matchEvent.Timestamp,
                matchEvent.Date,
                matchEvent.MatchId,
                matchEvent.ClockRunning));
        }

        if (!newMatchsEvents.Any())
            return Result<List<long>>.Success("No new events added.");


        await _repository.AddRangeAsync(newMatchsEvents);

        return Result<List<long>>.Success(newMatchsEvents.Select(p => p.Id).ToList());

    }
}