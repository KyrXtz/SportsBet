namespace SportsBet.Domain.Specifications.Leagues
{
    public class GetLeagueByIdSpecification : Specification<League>, ISingleResultSpecification<League>
    {
        public GetLeagueByIdSpecification(int id)
        {
            Query.Where(c => c.Id == id);
        }
    }
}
