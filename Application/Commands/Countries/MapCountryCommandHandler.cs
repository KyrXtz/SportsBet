namespace SportsBet.Application.Commands.Countries
{
    class MapCountryCommandHandler : IRequestHandler<MapCountryCommand, Result<Unit>>
    {
        private readonly IRepository<Country> _repository;

        public MapCountryCommandHandler(IRepository<Country> repository)
        {
            _repository = repository;
        }
        public async Task<Result<Unit>> Handle(MapCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _repository.FirstOrDefaultAsync(new GetCountriesByIdsSpecification(new[] { (long)request.Id }), cancellationToken);

            if (country != null)
            {
                country.Map(bBRegionId: request.BBRegionId, mappingAgentId: request.MappingAgentId);
                await _repository.UpdateAsync(country, cancellationToken);
            }

            return Result<Unit>.Success(Unit.Value, "Mapping succesful");
        }
    }
}
