namespace SportsBet.Domain.Aggregates.Squads;
public class Squad : BaseEntity<long>, IAggregateRoot
{
    public SquadInfo Info { get; private set; }
    public int CompetitorId { get; private set; }
    public int PlayerId { get; private set; }

    private Squad() { }
    internal Squad(SquadInfo info,
       int competitorId,
       int playerId)
    {
        Id = UniqueIdGenerator.CreateId();
        Info = info;
        CompetitorId = Guard.Against.InvalidInput(competitorId, nameof(competitorId), competitorId => competitorId > 0);
        PlayerId = Guard.Against.InvalidInput(playerId, nameof(playerId), playerId => playerId > 0);
    }
    public static Squad Create(PlayerRating rating,
        int? jerseyNumber,
        int competitorId,
        int playerId)
    {
        var info = SquadInfo.Create(rating, jerseyNumber);

        return new Squad(info, competitorId, playerId);
    }

    public void UpdateInfo(SquadInfo info)
    {
        Info = info;
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}