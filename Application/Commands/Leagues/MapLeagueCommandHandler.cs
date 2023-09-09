namespace SportsBet.Application.Commands.Leagues
{
    class MapLeagueCommandHandler : IRequestHandler<MapLeagueCommand, Result<Unit>>
    {
        private readonly IRepository<League> _repository;

        public MapLeagueCommandHandler(IRepository<League> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(MapLeagueCommand request, CancellationToken cancellationToken)
        {
            var league = await _repository.FirstOrDefaultAsync(new GetLeaguesByIdsSpecification(new[] { request.Id }),cancellationToken);

            if (league != null)
            {
                league.Map(bBLeagueId: request.BBLeagueId, mappingAgentId: request.MappingAgentId);
                await _repository.UpdateAsync(league, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Mapping successful");
        }
    }
}