namespace SportsBet.Domain.Specifications.Matches
{
    public class GetMatchsByBetContextIdsSpecification : Specification<Match>
    {
        public GetMatchsByBetContextIdsSpecification(params int[] betContextIds) 
        {
            Query.Where(c=>c.BetContext.BBEventHistoryId.HasValue && betContextIds.Contains(c.BetContext.BBEventHistoryId.Value));
        }
    }
}
