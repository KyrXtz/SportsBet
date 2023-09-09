namespace SportsBet.Application.Commands.Matches
{
    public class CreateUpdateMatchsStatsCommand : CommandBase, IRequest<Result<List<int>>>, IErroredCommand
    {
        public IEnumerable<MatchStatItem> MatchStats { get; private set; }
        private CreateUpdateMatchsStatsCommand() { }
        public CreateUpdateMatchsStatsCommand(IEnumerable<MatchStatItem> matchStats)
        {
            MatchStats = matchStats;
        }
    }

    public class MatchStatItem : CommandItemBase
    {
        public int MatchId { get; set; }
        public int EventId { get; set; }
        public string Value { get; set; }
        public int CompetitorId { get; set; }
        public int? PlayerId { get; set; }
    }
}