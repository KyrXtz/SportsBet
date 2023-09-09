namespace SportsBet.Application.Commands.Sports
{
    class MapSportCommandHandler : IRequestHandler<MapSportCommand, Result<Unit>>
    {
        private readonly IRepository<Sport> _repository;

        public MapSportCommandHandler(IRepository<Sport> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(MapSportCommand request, CancellationToken cancellationToken)
        {
            var sport = await _repository.FirstOrDefaultAsync(new GetSportsByIdsSpecification(new[] { request.Id }), cancellationToken);

            if (sport != null)
            {
                sport.Map(bBCompetitionContextId: request.BBCompetitionContextId, mappingAgentId: request.MappingAgentId);
                await _repository.UpdateAsync(sport, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Mapping successful");
        }
    }
}