namespace SportsBet.Application.Commands.Players
{
    class UnmapPlayerCommandHandler : IRequestHandler<UnmapPlayerCommand, Result<Unit>>
    {
        private readonly IRepository<Player> _repository;

        public UnmapPlayerCommandHandler(IRepository<Player> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(UnmapPlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _repository.FirstOrDefaultAsync(new GetPlayersByIdsSpecification( new[] { request.Id } ), cancellationToken);

            if (player != null)
            {
                player.Unmap();
                await _repository.UpdateAsync(player, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Unmapping successful");
        }
    }
}