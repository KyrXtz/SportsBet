namespace SportsBet.Domain.Specifications.Squads;
public class GetSquadsByCompetitorAndPlayerIdsSpecification : Specification<Squad>
{
    public GetSquadsByCompetitorAndPlayerIdsSpecification(int[] competitorIds, int[] playerIds)
    {          
        Query.Where(s => competitorIds.Contains(s.CompetitorId) && playerIds.Contains(s.PlayerId));
    }
}