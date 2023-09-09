namespace SportsBet.Domain.Specifications.Players;
public class GetPlayersByIdsSpecification : Specification<Player>
{
    public GetPlayersByIdsSpecification(params int[] ids)
    {
        Query.Where(p => ids.Contains(p.Id));
    }

    public GetPlayersByIdsSpecification(bool isMapped, params int[] ids)
    {
        Query.Where(p => p.BetContext.MappedAt.HasValue == isMapped && ids.Contains(p.Id));
    }
}
