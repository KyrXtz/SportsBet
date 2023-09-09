namespace SportsBet.Domain.ValueObjects.Squads;
public class SquadInfo : ValueObject
{
    public PlayerRating Rating { get; private set; }
    public int? JerseyNumber { get; private set; }

    internal SquadInfo(PlayerRating rating, int? jerseyNumber)
    {
        JerseyNumber = jerseyNumber;
        Rating = rating;
    }

    public static SquadInfo Create(PlayerRating rating, int? jerseyNumber)
    {
        return new SquadInfo(rating, jerseyNumber);
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Rating;
        yield return JerseyNumber;
    }
}