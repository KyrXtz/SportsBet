namespace SportsBet.Application.Commands.Leagues
{
    public class UnmapLeagueCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int Id { get; private set; }

        public UnmapLeagueCommand(int id)
        {
            Id = id;
        }
    }
}