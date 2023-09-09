using Competitor = SportsBet.Domain.Aggregates.Competitors.Competitor;

namespace SportsBet.Application.Commands.Competitors
{
    class CreateUpdateCompetitorCommandHandler : IRequestHandler<CreateUpdateCompetitorCommand, Result<List<int>>>
    {
        private readonly IRepository<Competitor> _repository;

        public CreateUpdateCompetitorCommandHandler(IRepository<Competitor> repository)
        {
            _repository = repository;
        }
        public async Task<Result<List<int>>> Handle(CreateUpdateCompetitorCommand request, CancellationToken cancellationToken)
        {
            var competitorIds = request.Competitors.Select(p => p.Id).Distinct().ToArray();

            var existingCompetitors = await _repository.ListAsync(new GetCompetitorsByIdsSpecification(competitorIds));

            var newCompetitors = new List<Competitor>();
            var updCompetitors = new List<Competitor>();

            foreach (var competitor in request.Competitors)
            {
                var existingCompetitor = existingCompetitors.SingleOrDefault(p => p.Id == competitor.Id);
                if (existingCompetitor != null)
                {
                    var competitorName = CompetitorName.Create(competitor.Name);

                    if (!existingCompetitor.CompetitorName.Equals(competitorName))
                    {
                        existingCompetitor.UpdateCompetitorName(competitorName);
                        updCompetitors.AddUniqueItem(existingCompetitor);
                    }

                    continue;
                }

                newCompetitors.Add(Competitor.Create(
                    id: competitor.Id,
                    name: competitor.Name,
                    isIndividual: competitor.IsIndividual,
                    sportId: competitor.SportId,
                    countryId: competitor.CountryId
                    ));
            }

            if (!newCompetitors.Any() & !updCompetitors.Any())
                return Result<List<int>>.Fail();

            var returnLst = new List<int>();

            if (newCompetitors.Any())
            {
                await _repository.AddRangeAsync(newCompetitors);
                returnLst.AddRange(newCompetitors.Select(p => p.Id).ToList());
            }

            if (updCompetitors.Any())
            {
                await _repository.UpdateRangeAsync(updCompetitors);
                returnLst.AddRange(updCompetitors.Select(p => p.Id).ToList());
            }

            return Result<List<int>>.Success(returnLst);
        }
    }
}