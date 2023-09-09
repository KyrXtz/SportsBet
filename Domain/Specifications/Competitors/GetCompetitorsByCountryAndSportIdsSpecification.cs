namespace SportsBet.Domain.Specifications.Competitors
{
    public class GetCompetitorsByCountryAndSportIdsSpecification : Specification<Competitor>
    {
        public GetCompetitorsByCountryAndSportIdsSpecification(int[] sportIds, params long[] countryIds)
        {
            Query.Where(c => sportIds.Contains(c.SportId) && countryIds.Contains(c.CountryId));
        }

        public GetCompetitorsByCountryAndSportIdsSpecification(bool isIndividual,int[] sportIds, params long[] countryIds)
        {
            Query.Where(c => sportIds.Contains(c.SportId) && countryIds.Contains(c.CountryId));
        }
    }
}
