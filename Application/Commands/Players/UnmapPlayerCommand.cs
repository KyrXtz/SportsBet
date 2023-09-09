namespace SportsBet.Application.Commands.Players
{
    public class UnmapPlayerCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int Id { get; private set; }

        public UnmapPlayerCommand(int id)
        {
            Id = id;
        }
    }
}