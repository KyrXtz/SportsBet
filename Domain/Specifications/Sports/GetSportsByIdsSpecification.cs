namespace SportsBet.Domain.Specifications.Sports
{
    public class GetSportsByIdsSpecification : Specification<Sport>
    {
        public GetSportsByIdsSpecification(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}
