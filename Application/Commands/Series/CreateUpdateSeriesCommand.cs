namespace SportsBet.Application.Commands.Series
{
    public class CreateUpdateSeriesCommand : CommandBase, IRequest<Result<List<long>>>, IErroredCommand
    {
        public IEnumerable<SeriesItem> Series { get; private set; }
        private CreateUpdateSeriesCommand() { }
        public CreateUpdateSeriesCommand(IEnumerable<SeriesItem> series)
        {
            Series = series;
        }

    }

    public class SeriesItem : CommandItemBase
    {
        public long Id { get; set; }
        public int NumberOfMatches { get; set; }
        public int Team1Id { get; set; }
        public int? Team1Score { get; set; }
        public int? Team1Standing { get; set; }
        public int Team2Id { get; set; }
        public int? Team2Score { get; set; }
        public int? Team2Standing { get; set; }
        public int? WinnerTeamId { get; set; }
        public List<SeriesMatchItem> SeriesMatches { get; set; } = new List<SeriesMatchItem>();
        public class SeriesMatchItem : CommandItemBase
        {
            public int Leg { get; set; }
            public int MatchId { get; set; }
            public int? Score1 { get; set; }
            public int? Standing1 { get; set; }
            public int? Score2 { get; set; }
            public int? Standing2 { get; set; }
        }
    }
}
