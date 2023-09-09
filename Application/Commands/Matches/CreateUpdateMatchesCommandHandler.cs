using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace SportsBet.Application.Commands.Matches
{
    internal class CreateUpdateMatchsCommandHandler : IRequestHandler<CreateUpdateMatchsCommand, Result<List<int>>>
    {
        private readonly IRepository<Match> _repository;

        public CreateUpdateMatchsCommandHandler(IRepository<Match> repository)
        {
            _repository = repository;
        }
        public async Task<Result<List<int>>> Handle(CreateUpdateMatchsCommand request, CancellationToken cancellationToken)
        {
            var matchsIds = request.Matches.Select(p => p.Id).ToArray();

            var existingMatchs = await _repository.ListAsync(new GetMatchsByIdsSpecification(matchsIds));

            var newMatchs = new List<Match>();
            var updMatchs = new List<Match>();

            foreach (var match in request.Matches)
            {
                var existingMatch = existingMatchs.FirstOrDefault(p => p.Id == match.Id);

                if (existingMatch != null)
                {
                    var matchName = MatchName.Create(name: match.Name);
                    var matchDate = MatchDate.Create(gameStart: match.Date);
                    var matchCompetitors = MatchCompetitors.Create(homeCompetitorId: match.HomeCompetitorId,
                        awayCompetitorId: match.AwayCompetitorId);

                    if (!existingMatch.Name.Equals(matchName))
                    {
                        existingMatch.UpdateMatchName(matchName);
                        updMatchs.AddUniqueItem(existingMatch);
                    }

                    if (!existingMatch.Status.Equals(match.Status))
                    {
                        existingMatch.UpdateMatchStatus(MatchStatus.FromValue(match.Status));
                        updMatchs.AddUniqueItem(existingMatch);
                    }

                    if (!existingMatch.Date.Equals(matchDate))
                    {
                        existingMatch.UpdateMatchDate(matchDate);
                        updMatchs.AddUniqueItem(existingMatch);
                    }

                    if (!existingMatch.Competitors.Equals(matchCompetitors))
                    {
                        existingMatch.UpdateMatchCompetitors(matchCompetitors);
                        updMatchs.AddUniqueItem(existingMatch);
                    }

                    continue;
                }

                newMatchs.Add(Match.Create(id: match.Id,
                    name: match.Name,
                    status: MatchStatus.FromValue(match.Status),
                    gameStart: match.Date,
                    homeCompetitorId: match.HomeCompetitorId,
                    awayCompetitorId: match.AwayCompetitorId,
                    sportId: match.SportId,
                    leagueId: match.LeagueId));
            }

            if (!newMatchs.Any() && !updMatchs.Any())
                return Result<List<int>>.Fail();

            var returnLst = new List<int>();

            if (newMatchs.Any())
            {
                await _repository.AddRangeAsync(newMatchs);
                returnLst.AddRange(newMatchs.Select(p => p.Id).ToList());
            }

            if (updMatchs.Any())
            {
                await _repository.UpdateRangeAsync(updMatchs);
                returnLst.AddRange(updMatchs.Select(p => p.Id).ToList());
            }

            return Result<List<int>>.Success(returnLst);
        }
    }
}