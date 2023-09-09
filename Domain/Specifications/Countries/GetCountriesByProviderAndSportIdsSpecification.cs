namespace SportsBet.Domain.Specifications.Countries;
public class GetCountriesByProviderAndSportIdsSpecification : Specification<Country>
{
    public GetCountriesByProviderAndSportIdsSpecification(int[] providerIds, int[] sportIds)
    {
        Query.Where(c => providerIds.Contains(c.ProviderId) && sportIds.Contains(c.SportId));
    }
}