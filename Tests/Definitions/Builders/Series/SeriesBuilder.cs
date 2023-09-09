namespace TestDefinitions.Builders
{
    public class SeriesBuilder
    {
        private int id = 1;
        private int numberOfMatches = 1;
        private int teamOneId = 1;
        private int? teamOneScore = 1;
        private int? teamOneStanding = 1;
        private int teamTwoId = 1;
        private int? teamTwoScore = 1;
        private int? teamTwoStanding = 1;
        private int? winnerTeamId = 1;
        private SeriesMatch seriesMatch;

        public Series Build()
        {
            var series = Series.Create(
                numberOfMatches,
                teamOneId,
                teamOneScore,
                teamOneStanding,
                teamTwoId,
                teamTwoScore,
                teamTwoStanding,
                winnerTeamId
                );

            if (seriesMatch != null)
                series.AddSeriesMatch(seriesMatch);

            return series;
        }
        public SeriesBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }
        public SeriesBuilder WithSeriesInfo(int numberOfMatches)
        {
            this.numberOfMatches = numberOfMatches;
            return this;
        }
        public SeriesBuilder WithSeriesTeamOne(int teamOneId)
        {
            this.teamOneId = teamOneId;
            return this;
        }
        public SeriesBuilder WithSeriesScoreOne(int teamOneScore, int teamOneStanding)
        {
            this.teamOneScore = teamOneScore;
            this.teamOneStanding = teamOneStanding;
            return this;
        }
        public SeriesBuilder WithSeriesTeamTwo(int teamTwoId)
        {
            this.teamTwoId = teamTwoId;
            return this;
        }
        public SeriesBuilder WithSeriesScoreTwo(int teamTwoScore, int teamTwoStanding)
        {
            this.teamTwoScore = teamTwoScore;
            this.teamTwoStanding = teamTwoStanding;
            return this;
        }
        public SeriesBuilder WithWinnerTeamId(int winnerTeamId)
        {
            this.winnerTeamId = winnerTeamId;
            return this;
        }
        public SeriesBuilder WithSeriesMatch(int leg, int matchId)
        {
            this.seriesMatch = SeriesMatch.Create(leg, matchId);
            return this;
        }
    public SeriesBuilder WithSeriesMatchScores(int leg, int matchId)
    {
        this.seriesMatch = SeriesMatch.Create(leg, matchId);
        return this;
    }

    public static implicit operator Series(SeriesBuilder instance)
        {
            return instance.Build();
        }
    }
}
