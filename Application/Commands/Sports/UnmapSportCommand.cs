namespace SportsBet.Application.Commands.Sports
{
    public class UnmapSportCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int Id { get; private set; }

        public UnmapSportCommand(int id)
        {
            Id = id;
        }
    }
}