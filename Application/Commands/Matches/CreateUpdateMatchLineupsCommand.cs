namespace SportsBet.Application.Commands.Matches
{
    public class CreateUpdateMatchsLineupsCommand : CommandBase, IRequest<Result<List<int>>>, IErroredCommand
    {
        public IEnumerable<MatchLineupItem> MatchLineups { get; private set; }
        private CreateUpdateMatchsLineupsCommand() { }
        public CreateUpdateMatchsLineupsCommand(IEnumerable<MatchLineupItem> matchLineups)
        {
            MatchLineups = matchLineups;
        }
    }

    public class MatchLineupItem : CommandItemBase
    {
        public int MatchId { get; set; }
        public int Type { get; set; }
        public int CompetitorId { get; set; }
        public int PlayerId { get; set; }
        public int SportId { get; set; }
        public bool IsHome { get; set; }
    }
}