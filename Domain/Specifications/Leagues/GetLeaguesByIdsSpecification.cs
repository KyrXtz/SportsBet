namespace SportsBet.Domain.Specifications.Leagues
{
    public class GetLeaguesByIdsSpecification : Specification<League>
    {
        public GetLeaguesByIdsSpecification(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }

        public GetLeaguesByIdsSpecification(bool isMapped, params int[] ids)
        {
            Query.Where(c => c.BetContext.BBCompetitionId.HasValue == isMapped && ids.Contains(c.Id));
        }
    }
}