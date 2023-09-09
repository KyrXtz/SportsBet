namespace SportsBet.Domain.Aggregates.Matches;
public abstract class MatchLineup : BaseEntity<long>
{
    public MatchLineupType Type { get; protected set; }
    public int CompetitorId { get; protected set; }
    public int? PlayerId { get; protected set; }
    public int SportId { get; protected set; }

    protected MatchLineup() { }

    public static MatchLineup Create(MatchLineupType type,
        int competitorId,
        int? playerId,
        int sportId,
        bool isHome)
    {
        return isHome switch
        {
            true => CreateHomeLineup(type: type, competitorId: competitorId, playerId: playerId, sportId: sportId),
            false => CreateAwayLineup(type: type, competitorId: competitorId, playerId: playerId, sportId: sportId)
        };
    }
    private static MatchLineupHome CreateHomeLineup(MatchLineupType type,
        int competitorId,
        int? playerId,
        int sportId)
    {
        return new MatchLineupHome(type,
            competitorId, playerId, sportId);
    }
    private static MatchLineupAway CreateAwayLineup(MatchLineupType type,
        int competitorId,
        int? playerId,
        int sportId)
    {
        return new MatchLineupAway(type,
            competitorId, playerId, sportId);
    }

    internal void UpdateLineupType(MatchLineupType type)
    {
        Type = type;
    }


    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}
public class MatchLineupHome : MatchLineup 
{
    internal MatchLineupHome(MatchLineupType type,
        int competitorId,
        int? playerId,
        int sportId)
    {
        Id = UniqueIdGenerator.CreateId();
        Type = type;
        CompetitorId = Guard.Against.InvalidInput(competitorId, nameof(competitorId), competitorId => competitorId > 0);
        PlayerId = playerId.HasValue ? Guard.Against.InvalidInput(playerId, nameof(playerId), playerId => playerId >= 0) : playerId;
        SportId = Guard.Against.InvalidInput(sportId, nameof(sportId), sportId => sportId > 0);
    }
}
public class MatchLineupAway : MatchLineup 
{
    internal MatchLineupAway(MatchLineupType type,
        int competitorId,
        int? playerId,
        int sportId)
    {
        Id = UniqueIdGenerator.CreateId();
        Type = type;
        CompetitorId = Guard.Against.InvalidInput(competitorId, nameof(competitorId), competitorId => competitorId > 0);
        PlayerId = playerId.HasValue ? Guard.Against.InvalidInput(playerId, nameof(playerId), playerId => playerId >= 0) : playerId;
        SportId = Guard.Against.InvalidInput(sportId, nameof(sportId), sportId => sportId > 0);
    }
}
