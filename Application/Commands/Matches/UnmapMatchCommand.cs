namespace SportsBet.Application.Commands.Matches;
public class UnmapMatchCommand : CommandBase, IRequest<Result<Unit>>
{
    public int Id { get; private set; }

    public UnmapMatchCommand(int id)
    {
        Id = id;
    }
}