using Competitor = SportsBet.Domain.Aggregates.Competitors.Competitor;

namespace SportsBet.Application.Commands.Competitors
{
    class MapCompetitorCommandHandler : IRequestHandler<MapCompetitorCommand, Result<Unit>>
    {
        private readonly IRepository<Competitor> _repository;

        public MapCompetitorCommandHandler(IRepository<Competitor> repository)
        {
            _repository = repository;
        }

        public async Task<Result<Unit>> Handle(MapCompetitorCommand request, CancellationToken cancellationToken)
        {
            var competitor = await _repository.FirstOrDefaultAsync(new GetCompetitorsByIdsSpecification(new[] { request.Id }), cancellationToken);

            if (competitor != null)
            {
                competitor.Map(bBCompetitorId: request.BBCompetitorId, mappingAgentId: request.MappingAgentId);
                await _repository.UpdateAsync(competitor, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Mapping successful");
        }
    }
}