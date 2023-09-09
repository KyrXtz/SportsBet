
namespace SportsBet.Domain.Specifications.Matches
{
    public class GetMatchsByCompetitorIdSpecification : Specification<Match>
    {
        public GetMatchsByCompetitorIdSpecification(int id)
        {
            Query.Where(m => m.Competitors.HomeCompetitorId == id || m.Competitors.AwayCompetitorId == id);
        }

        public GetMatchsByCompetitorIdSpecification(bool isMapped, int id)
        {
            Query.Where(m => m.BetContext.BBEventHistoryId.HasValue == isMapped && (m.Competitors.HomeCompetitorId == id || m.Competitors.AwayCompetitorId == id));
        }
    }
}
