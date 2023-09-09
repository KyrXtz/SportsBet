namespace SportsBet.Domain.Specifications.Series
{
    public class GetSeriesByIdsSpecification : Specification<Domain.Aggregates.Series.Series>
    {
        public GetSeriesByIdsSpecification(params long[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}
