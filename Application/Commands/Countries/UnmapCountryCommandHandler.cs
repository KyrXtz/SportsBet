namespace SportsBet.Application.Commands.Countries
{
    class UnmapCountryCommandHandler : IRequestHandler<UnmapCountryCommand, Result<Unit>>
    {
        private readonly IRepository<Country> _repository;

        public UnmapCountryCommandHandler(IRepository<Country> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(UnmapCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _repository.FirstOrDefaultAsync(new GetCountriesByIdsSpecification(new[] { (long)request.Id }), cancellationToken);

            if (country != null)
            {
                country.Unmap();
                await _repository.UpdateAsync(country, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Unmapping successful"); 
        }
    }
}