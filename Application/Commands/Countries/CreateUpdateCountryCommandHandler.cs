namespace SportsBet.Application.Commands.Countries;
class CreateUpdateCountryCommandHandler : IRequestHandler<CreateUpdateCountryCommand, Result<List<long>>>
{
    private readonly IRepository<Country> _repository;

    public CreateUpdateCountryCommandHandler(IRepository<Country> repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<long>>> Handle(CreateUpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var providerCountryIds = request.Countries.Select(p => p.ProviderId).ToArray();
        var sportIds = request.Countries.Select(p => p.SportId).ToArray();

        var existingCountries = await _repository.ListAsync(new GetCountriesByProviderAndSportIdsSpecification(providerCountryIds, sportIds));

        var newCountries = new List<Country>();
        var updCountries = new List<Country>();

        foreach (var country in request.Countries)
        {
            var existingCountry = existingCountries
                .FirstOrDefault(p => p.ProviderId == country.ProviderId && p.SportId == country.SportId);

            if (existingCountry != null)
            {
                var countryName = CountryName.Create(code: country.ISOCode,
                    name: country.Name);

                if (!existingCountry.Name.Equals(countryName))
                {
                    existingCountry.UpdateCountryName(countryName);
                    updCountries.AddUniqueItem(existingCountry);
                }

                continue;
            }

            newCountries.Add(Country.Create(
                providerId : country.ProviderId,
                code: country.ISOCode,
                name: country.Name,
                sportId: country.SportId));
        }

        if (!newCountries.Any() && !updCountries.Any())
            return Result<List<long>>.Fail();

        var returnLst = new List<long>();

        if (newCountries.Any())
        {
            await _repository.AddRangeAsync(newCountries);
            returnLst.AddRange(newCountries.Select(p => p.Id).ToList());
        }

        if (updCountries.Any())
        {
            await _repository.UpdateRangeAsync(updCountries);
            returnLst.AddRange(updCountries.Select(p => p.Id).ToList());
        }

        return Result<List<long>>.Success(returnLst);
    }
}