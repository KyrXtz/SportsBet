namespace SportsBet.Application.Commands.Leagues
{
    public class CreateUpdateLeagueCommand : CommandBase, IRequest<Result<List<int>>>
    {
        public IEnumerable<LeagueItem> Leagues { get; private set; }

        public CreateUpdateLeagueCommand(IEnumerable<LeagueItem> leagues)
        {
            Leagues = leagues;
        }
    }

    public class LeagueItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }
        public int SportId { get; set; }
    }
}
