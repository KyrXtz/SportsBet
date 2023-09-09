namespace SportsBet.Application.Commands.Players
{
    class MapPlayerCommandHandler : IRequestHandler<MapPlayerCommand, Result<Unit>>
    {
        private readonly IRepository<Player> _repository;

        public MapPlayerCommandHandler(IRepository<Player> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(MapPlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _repository.FirstOrDefaultAsync(new GetPlayersByIdsSpecification(new[] { request.Id }), cancellationToken);

            if (player != null)
            {
                player.Map(bBPlayerId: request.BBPlayerId, mappingAgentId: request.MappingAgentId);
                await _repository.UpdateAsync(player, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Mapping successful");
        }
    }
}