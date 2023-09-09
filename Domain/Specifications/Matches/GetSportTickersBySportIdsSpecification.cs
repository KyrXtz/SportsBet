namespace SportsBet.Domain.Specifications.Matches
{
    public class GetSportTickersBySportIdsSpecification : Specification<Match>
    {
        public GetSportTickersBySportIdsSpecification(params int[] ids)
        {
            Query.Where(t => ids.Contains(t.Id));
        }

        public GetSportTickersBySportIdsSpecification(bool isMapped, params int[] ids)
        {
            Query.Where(t => t.BetContext.BBEventHistoryId.HasValue == isMapped && ids.Contains(t.Id));
        }
    }
}
