namespace SportsBet.Domain.Specifications.Competitors
{
    public class GetCompetitorsByCountryIdsSpecification : Specification<Domain.Aggregates.Competitors.Competitor>
    {
        public GetCompetitorsByCountryIdsSpecification(params long[] countryIds)
        {
            Query.Where(c => countryIds.Contains(c.CountryId));
        }

        public GetCompetitorsByCountryIdsSpecification(bool isMapped, params long[] countryIds)
        {
            Query.Where(c => c.BetContext.MappedAt.HasValue == isMapped && countryIds.Contains(c.CountryId));
        }
    }
}
