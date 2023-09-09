namespace SportsBet.Domain.Specifications.Countries
{
    public class GetCountriesByIdsSpecification : Specification<Country>
    {
        public GetCountriesByIdsSpecification(params long[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}

