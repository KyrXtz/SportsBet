namespace SportsBet.Application.Commands.Leagues
{
    class UnmapLeagueCommandHandler : IRequestHandler<UnmapLeagueCommand, Result<Unit>>
    {
        private readonly IRepository<League> _repository;

        public UnmapLeagueCommandHandler(IRepository<League> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(UnmapLeagueCommand request, CancellationToken cancellationToken)
        {
            var league = await _repository.FirstOrDefaultAsync(new GetLeaguesByIdsSpecification(new[] { request.Id }), cancellationToken);

            if (league != null)
            {
                league.Unmap();
                await _repository.UpdateAsync(league, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Unmapping successful");
        }
    }
}