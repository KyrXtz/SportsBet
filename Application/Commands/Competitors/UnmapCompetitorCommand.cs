namespace SportsBet.Application.Commands.Competitors
{
    public class UnmapCompetitorCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int Id { get; private set; }

        public UnmapCompetitorCommand(int id)
        {
            Id = id;
        }
    }
}