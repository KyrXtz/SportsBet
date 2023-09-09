namespace SportsBet.Domain.Specifications.Series
{
    public class GetSeriesByMatchIdsSpecification : Specification<Domain.Aggregates.Series.Series>
    {
        public GetSeriesByMatchIdsSpecification(int[] ids, bool fetchMatchEvents = false)
        {
            if (fetchMatchEvents)
                Query.Where(c => c.SeriesMatches.Any(sm => ids.Contains(sm.MatchId))).Include(s => s.SeriesMatches);
            else
                Query.Where(c => c.SeriesMatches.Any(sm => ids.Contains(sm.MatchId)));
        }
    }
}