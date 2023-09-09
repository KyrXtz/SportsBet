namespace SportsBet.Application.Commands.MatchesEvents;

internal class UpdateMatchsEventsCommandHandler : IRequestHandler<UpdateMatchsEventsCommand, Result<List<long>>>
{
    private readonly IRepository<MatchEvent> _repository;

    public UpdateMatchsEventsCommandHandler(IRepository<MatchEvent> repository)
    {
        _repository = repository;
    }
    public async Task<Result<List<long>>> Handle(UpdateMatchsEventsCommand request, CancellationToken cancellationToken)
    {
        var matchIds = request.MatchSpecialEvents.Select(p => p.MatchId).ToArray();
        var existingMatchsEvents = await _repository.ListAsync(new GetMatchsEventsByMatchIdSpecification(matchIds));

        var updMatchsEvents = new List<MatchEvent>();

        foreach (var matchEvent in request.MatchSpecialEvents)
        {
            var existingMatchEvent = existingMatchsEvents.FirstOrDefault(e => e.MatchId == matchEvent.MatchId
                && e.Info.EventNumber == matchEvent.EventNumber);

            if (existingMatchEvent != null)
            {
                var eventReason = MatchEventReason.Create(matchEvent.EventReasonId, matchEvent.EventReasonValue);
                if (!existingMatchEvent.Reason.Equals(eventReason))
                {
                    existingMatchEvent.AddEventReason(eventReason);
                    updMatchsEvents.AddUniqueItem(existingMatchEvent);
                }

                if (matchEvent.SpecialEventValues.Any())
                {
                    existingMatchEvent.AddSpecialEvent(matchEvent.SpecialEventValues);
                    updMatchsEvents.AddUniqueItem(existingMatchEvent);
                }

                if (matchEvent.RelatedMatchEventNumbers.Any())
                {
                    existingMatchEvent.AddRelatedMatchEventNumbers(matchEvent.RelatedMatchEventNumbers);
                    updMatchsEvents.AddUniqueItem(existingMatchEvent);
                }

                if (matchEvent.ClearedMatchEventNumbers.Any())
                {
                    existingMatchEvent.AddClearedMatchEventNumbers(matchEvent.RelatedMatchEventNumbers);
                    updMatchsEvents.AddUniqueItem(existingMatchEvent);
                }
            }                         
        }

        if (!updMatchsEvents.Any())
            return Result<List<long>>.Success("No events updated.");

        await _repository.UpdateRangeAsync(updMatchsEvents);

        return Result<List<long>>.Success(updMatchsEvents.Select(p => p.Id).ToList());

    }
}