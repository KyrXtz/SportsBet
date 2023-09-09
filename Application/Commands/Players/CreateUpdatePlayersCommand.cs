namespace SportsBet.Application.Commands.Players;
public class CreateUpdatePlayersCommand : CommandBase, IRequest<Result<List<int>>>, IErroredCommand
{
    public IEnumerable<PlayerItem> Players { get; private set; }
    private CreateUpdatePlayersCommand() { }
    public CreateUpdatePlayersCommand(IEnumerable<PlayerItem> players)
    {
        Players = players;
    }
}

public class PlayerItem : CommandItemBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public int ProviderCountryId { get; set; }
}