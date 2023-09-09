namespace SportsBet.Application.Commands.Leagues
{
    class CreateUpdateLeagueCommandHandler : IRequestHandler<CreateUpdateLeagueCommand, Result<List<int>>>
    {
        private readonly IRepository<League> _repository;

        public CreateUpdateLeagueCommandHandler(IRepository<League> repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<int>>> Handle(CreateUpdateLeagueCommand request, CancellationToken cancellationToken)
        {
            var leagueIds = request.Leagues.Select(p => p.Id).ToArray();

            var existingLeagues = await _repository.ListAsync(new GetLeaguesByIdsSpecification(leagueIds));
           
            var newLeagues = new List<League>();
            var updLeagues = new List<League>();

            foreach (var league in request.Leagues)
            {
                var existingLeague = existingLeagues.FirstOrDefault(p => p.Id == league.Id);
                if (existingLeague != null)
                {
                    var leagueName = LeagueName.Create(name: league.Name);

                    if (!existingLeague.Name.Equals(leagueName))
                    {
                        existingLeague.UpdateLeagueName(leagueName);
                        updLeagues.AddUniqueItem(existingLeague);
                    }

                    continue;
                }

                newLeagues.Add(League.Create(
                    id: league.Id,
                    name: league.Name,
                    countryId: league.CountryId,
                    sportId: league.SportId));
            }

            if (!newLeagues.Any() && !updLeagues.Any())
                return Result<List<int>>.Fail();

            var returnLst = new List<int>();

            if (newLeagues.Any())
            {
                await _repository.AddRangeAsync(newLeagues);
                returnLst.AddRange(newLeagues.Select(p => p.Id).ToList());
            }

            if (updLeagues.Any())
            {
                await _repository.UpdateRangeAsync(updLeagues);
                returnLst.AddRange(updLeagues.Select(p => p.Id).ToList());
            }

            return Result<List<int>>.Success(returnLst);
        }
    }
}