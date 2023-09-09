namespace SportsBet.Domain.Specifications.MatchesEvents;
public class GetMatchsEventsByMatchIdSpecification : Specification<MatchEvent>
{
    public GetMatchsEventsByMatchIdSpecification(params int[] matchIds)
    {
        Query.Where(e => matchIds.Contains(e.MatchId));
    }
}