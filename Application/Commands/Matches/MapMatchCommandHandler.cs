using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace SportsBet.Application.Commands.Matches;
class MapMatchCommandHandler : IRequestHandler<MapMatchCommand, Result<Unit>>
{
    private readonly IRepository<Match> _repository;

    public MapMatchCommandHandler(IRepository<Match> repository)
    {
        _repository = repository;
    }
    public async Task<Result<Unit>> Handle(MapMatchCommand request, CancellationToken cancellationToken)
    {
        var match = await _repository.FirstOrDefaultAsync(new GetMatchsByIdsSpecification(new[] { request.Id }), cancellationToken);

        if (match != null)
        {
            match.Map(bBEventHistoryId: request.BBEventHistoryId, mappingAgentId: request.MappingAgentId);
            await _repository.UpdateAsync(match, cancellationToken);
        }

        return Result<Unit>.Success(Unit.Value, "Mapping successful");
    }
}