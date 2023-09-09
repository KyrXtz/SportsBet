using Competitor = SportsBet.Domain.Aggregates.Competitors.Competitor;

namespace SportsBet.Application.Commands.Competitors
{
    class UnmapCompetitorCommandHandler : IRequestHandler<UnmapCompetitorCommand, Result<Unit>>
    {
        private readonly IRepository<Competitor> _repository;

        public UnmapCompetitorCommandHandler(IRepository<Competitor> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(UnmapCompetitorCommand request, CancellationToken cancellationToken)
        {
            var competitor = await _repository.FirstOrDefaultAsync(new GetCompetitorsByIdsSpecification(new[] { request.Id }),cancellationToken);

            if (competitor != null)
            {
                competitor.Unmap();
                await _repository.UpdateAsync(competitor, cancellationToken);
            }

            return Result<Unit>.Success("UnMapping successful");
        }
    }
}