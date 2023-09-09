using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace SportsBet.Application.Commands.Matches;
class UnmapMatchCommandHandler : IRequestHandler<UnmapMatchCommand, Result<Unit>>
{
    private readonly IRepository<Match> _repository;

    public UnmapMatchCommandHandler(IRepository<Match> repository)
    {
        _repository = repository;
    }
    public async Task<Result<Unit>> Handle(UnmapMatchCommand request, CancellationToken cancellationToken)
    {
        var match = await _repository.FirstOrDefaultAsync(new GetMatchsByIdsSpecification( new[] { request.Id } ), cancellationToken);

        if (match != null)
        {
            match.Unmap();
            await _repository.UpdateAsync(match, cancellationToken);
        }

        return Result<Unit>.Success(Unit.Value, "Unmapping successful");
    }
}