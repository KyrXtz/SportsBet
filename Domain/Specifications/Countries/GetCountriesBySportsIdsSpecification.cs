namespace SportsBet.Domain.Specifications.Countries
{
    public class GetCountriesBySportsIdsSpecification : Specification<Country>
    {
        public GetCountriesBySportsIdsSpecification(int[] sportIds)
        {
            Query.Where(c =>sportIds.Contains(c.SportId));
        }
    }
}
