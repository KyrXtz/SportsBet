using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace SportsBet.Application.Commands.Matches
{
    internal class CreateUpdateMatchsStatsCommandHandler : IRequestHandler<CreateUpdateMatchsStatsCommand, Result<List<int>>>
    {
        private readonly IRepository<Match> _repository;

        public CreateUpdateMatchsStatsCommandHandler(IRepository<Match> repository)
        {
            _repository = repository;
        }
        public async Task<Result<List<int>>> Handle(CreateUpdateMatchsStatsCommand request, CancellationToken cancellationToken)
        {
            var matchIds = request.MatchStats.Select(p => p.MatchId).ToArray();

            var existingMatchs = await _repository.ListAsync(new GetMatchsByIdsSpecification(matchIds));

            var updMatchs = new List<Match>();

            foreach (var match in existingMatchs)
            {
                var existingMatch = existingMatchs.FirstOrDefault(p => p.Id == match.Id);

                if (existingMatch != null)
                {
                    var matchStats = request.MatchStats.Where(st => st.MatchId == match.Id)
                        .Select(st => MatchStat.Create(st.EventId,
                            st.Value,
                            st.CompetitorId,
                            st.PlayerId));

                    existingMatch.AddOrUpdateStats(matchStats);
                    updMatchs.AddUniqueItem(match);
                }
            }

            if (!updMatchs.Any())
                return Result<List<int>>.Fail();


            await _repository.UpdateRangeAsync(updMatchs);
            
            return Result<List<int>>.Success(updMatchs.Select(p => p.Id).ToList());
        }
    }
}