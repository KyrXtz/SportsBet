using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace SportsBet.Application.Commands.Matches;
internal class CreateUpdateMatchsLineupsCommandHandler : IRequestHandler<CreateUpdateMatchsLineupsCommand, Result<List<int>>>
{
    private readonly IRepository<Match> _repository;

    public CreateUpdateMatchsLineupsCommandHandler(IRepository<Match> repository)
    {
        _repository = repository;
    }
    public async Task<Result<List<int>>> Handle(CreateUpdateMatchsLineupsCommand request, CancellationToken cancellationToken)
    {
        var matchIds = request.MatchLineups.Select(p => p.MatchId).ToArray();

        var existingMatchs = await _repository.ListAsync(new GetMatchsByIdsSpecification(ids: matchIds, fetchMatchLineups: true));

        var updMatchs = new List<Match>();

        foreach (var match in existingMatchs)
        {
            var existingMatch = existingMatchs.FirstOrDefault(p => p.Id == match.Id);

            if (existingMatch != null)
            {
                var matchLineups = request.MatchLineups.Where(st => st.MatchId == match.Id)
                    .Select(l => MatchLineup.Create(MatchLineupType.FromValue(l.Type),
                        l.CompetitorId,
                        l.PlayerId,
                        l.SportId,
                        l.IsHome));

                existingMatch.AddOrUpdateLineup(matchLineups);
                updMatchs.AddUniqueItem(match);
            }
        }

        if (!updMatchs.Any())
            return Result<List<int>>.Fail();


        await _repository.UpdateRangeAsync(updMatchs);
            
        return Result<List<int>>.Success(updMatchs.Select(p => p.Id).ToList());
    }
}