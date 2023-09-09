namespace SportsBet.Application.Commands.Matches
{
    public class CreateUpdateMatchsCommand : CommandBase, IRequest<Result<List<int>>>, IErroredCommand
    {
        public IEnumerable<MatchItem> Matches { get; private set; }
        private CreateUpdateMatchsCommand() { }
        public CreateUpdateMatchsCommand(IEnumerable<MatchItem> matches)
        {
            Matches = matches;
        }
    }
    public class MatchItem : CommandItemBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public int HomeCompetitorId { get; set; }
        public int AwayCompetitorId { get; set; }
        public int SportId { get; set; }
        public int LeagueId { get; set; }
    }
}
