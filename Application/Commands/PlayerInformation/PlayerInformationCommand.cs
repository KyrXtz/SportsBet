namespace SportsBet.Application.Commands.PlayerInformation;

public class PlayerInformationCommand : Webhook
{
    public PlayerInformationPayload Payload { get; private set; }
    private PlayerInformationCommand() { }
    public PlayerInformationCommand(PlayerInformationPayload payload)
    {
        Payload = payload;
    }
}

#region Payload Records
public record PlayerInformationPayload(PlayerInformationList PlayerList)
{
    public PlayerInformationPayload() : this(new PlayerInformationList(new List<PlayerInformation>(), DateTime.UtcNow,
        default))
    {
    }
}

public record PlayerInformationList(
    IReadOnlyList<PlayerInformation> Players,
    DateTime DateGenerated,
    int PusherId
)
{
    public PlayerInformationList() : this(new List<PlayerInformation>(), DateTime.UtcNow, default)
    {
    }
}

public record PlayerInformation(
    IReadOnlyList<PlayerInformationLineup> Lineup,
    int Id,
    string Name,
    int CountryId,
    string Country,
    int PositionId,
    string Position,
    string Changetime
)
{
    public PlayerInformation() : this(new List<PlayerInformationLineup>(), default, string.Empty, default, string.Empty,
        default,
        string.Empty, string.Empty)
    {
    }
}

public record PlayerInformationLineup(
    int CompetitorId,
    int RatingId,
    string Rating,
    int JerseyNumber
)
{
    public PlayerInformationLineup() : this(default, default, string.Empty, default)
    {
    }
}
#endregion