namespace SportsBet.Application.Commands.Sports
{
    class UnmapSportCommandHandler : IRequestHandler<UnmapSportCommand, Result<Unit>>
    {
        private readonly IRepository<Sport> _repository;

        public UnmapSportCommandHandler(IRepository<Sport> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(UnmapSportCommand request, CancellationToken cancellationToken)
        {
            var sport = await _repository.FirstOrDefaultAsync(new GetSportsByIdsSpecification(new[] { request.Id }), cancellationToken);

            if (sport != null)
            {
                sport.Unmap();
                await _repository.UpdateAsync(sport, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Unmapping successful");
        }
    }
}