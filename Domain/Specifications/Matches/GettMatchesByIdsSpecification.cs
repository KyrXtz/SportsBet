namespace SportsBet.Domain.Specifications.SporsTickers
{
    public class GetMatchsByIdsSpecification : Specification<Match>
    {
        public GetMatchsByIdsSpecification(int[] ids, bool fetchMatchEvents = false, bool fetchMatchLineups = false)
        {
            if (fetchMatchEvents)
                Query.Where(s => ids.Contains(s.Id)).Include(s => s.MatchEvents);
            else if (fetchMatchLineups)
                Query.Where(s => ids.Contains(s.Id)).Include(s => s.HomeLineup).Include(s => s.AwayLineup);
            else
                Query.Where(s => ids.Contains(s.Id));
        }

        public GetMatchsByIdsSpecification(bool isMapped, params int[] ids) //todo remove
        {
            Query.Where(m => m.BetContext.BBEventHistoryId.HasValue == isMapped && ids.Contains(m.Id));
        }
    }
}