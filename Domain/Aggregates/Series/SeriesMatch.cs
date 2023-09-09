namespace SportsBet.Domain.Aggregates.Series
{
    public class SeriesMatch : BaseEntity<long>
    {
        public int Leg { get; private set; }
        public int MatchId { get; private set; }
        public SeriesScore Score1 { get; private set; }
        public SeriesScore Score2 { get; private set; }
        private SeriesMatch() { }

        internal SeriesMatch(int leg,
            int matchId)
        {
            Id = UniqueIdGenerator.CreateId();
            Leg = Guard.Against.InvalidInput(leg, nameof(leg), leg => leg > 0);
            MatchId = Guard.Against.InvalidInput(matchId, nameof(matchId), matchId => matchId > 0);
        }
        public static SeriesMatch Create(int leg,
            int matchId)
        {
            var seriesMatch = new SeriesMatch(leg: leg,
                matchId: matchId);

            return seriesMatch;
        }

        internal void Update(int? score1, int? standing1,
            int? score2, int? standing2)
        {
            var seriesScore1 = SeriesScore.Create(score1, standing1);
            var seriesScore2 = SeriesScore.Create(score2, standing2);

            Score1 = seriesScore1;
            Score2 = seriesScore2;
        }

        internal void UpdateSeriesMatchScore1(SeriesScore score1)
        {
            Score1 = score1;
        }

        internal void UpdateSeriesMatchScore2(SeriesScore score2)
        {
            Score2 = score2;
        }

        internal void UpdateLeg(int leg)
        {
            Leg = leg;
        }

        internal void UpdateMatchId(int matchId)
        {
            MatchId = matchId;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
