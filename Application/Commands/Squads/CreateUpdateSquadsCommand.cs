namespace SportsBet.Application.Commands.Squads;
public class CreateUpdateSquadsCommand : CommandBase, IRequest<Result<List<long>>>, IErroredCommand
{
    public IEnumerable<SquadItem> Squads { get; private set; }
    private CreateUpdateSquadsCommand() { }
    public CreateUpdateSquadsCommand(IEnumerable<SquadItem> squads)
    {
        Squads = squads;
    }
}

public class SquadItem : CommandItemBase
{
    public int CompetitorId { get; set; }
    public int PlayerId { get; set; }
    public int Rating { get; set; }
    public int? JerseyNumber { get; set; }
}