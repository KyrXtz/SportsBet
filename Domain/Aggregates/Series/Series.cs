namespace SportsBet.Domain.Aggregates.Series
{
    public class Series : BaseEntity<long>, IAggregateRoot
    {
        public SeriesInfo Info { get; private set; }
        public SeriesTeam Team1 { get; private set; }
        public SeriesTeam Team2 { get; private set; }
        public int? WinnerTeamId { get; private set; }

        private List<SeriesMatch> _seriesMatches = new List<SeriesMatch>();
        public IReadOnlyCollection<SeriesMatch> SeriesMatches => _seriesMatches.AsReadOnly();

        private Series() { }

        internal Series(SeriesInfo info,
            SeriesTeam team1,
            SeriesTeam team2,
            int? winnerTeamId)
        {
            Id = UniqueIdGenerator.CreateId();
            Info = info;
            Team1 = team1;
            Team2 = team2;
            WinnerTeamId = winnerTeamId;

            _domainEvents.Add(new SeriesAddedEvent(this));
        }

        public static Series Create(int numberOfMatches,
            int teamOneId,
            int? teamOneScore,
            int? teamOneStanding,
            int teamTwoId,
            int? teamTwoScore,
            int? teamTwoStanding,
            int? winnerTeamId)
        {
            var seriesInfo = SeriesInfo.Create(numberOfMatches);

            var team1Score = SeriesScore.Create(teamOneScore, teamOneStanding);
            var team1 = SeriesTeam.Create(teamOneId, team1Score);

            var team2Score = SeriesScore.Create(teamTwoScore, teamTwoStanding);
            var team2 = SeriesTeam.Create(teamTwoId, team2Score);


            var series = new Series(info: seriesInfo, team1: team1, team2: team2, winnerTeamId: winnerTeamId);

            return series;
        }

        public void Update(SeriesTeam team1,
            SeriesTeam team2,
            int? winnerTeamId)
        {
            Team1 = team1;
            Team2 = team2;
            WinnerTeamId = winnerTeamId;

            _domainEvents.Add(new SeriesUpdatedEvent(this));
        }
        public void CreateUpdateTeam1(int teamId)
        {
            Team1 = SeriesTeam.Create(teamId, Team1.Score);

            _domainEvents.Add(new SeriesUpdatedEvent(this));
        }
        public void CreateUpdateTeam2(int teamId)
        {
            Team2 = SeriesTeam.Create(teamId, Team2.Score);

            _domainEvents.Add(new SeriesUpdatedEvent(this));
        }
        public void CreateUpdateScore1(SeriesScore score1)
        {
            Team1 = SeriesTeam.Create(Team1.TeamId, score1);

            _domainEvents.Add(new SeriesUpdatedEvent(this));
        }
        public void CreateUpdateScore2(SeriesScore score2)
        {
            Team2 = SeriesTeam.Create(Team2.TeamId, score2);

            _domainEvents.Add(new SeriesUpdatedEvent(this));
        }
        public void UpdateWinner(int? winnerTeamId)
        {
            if (winnerTeamId == null || (winnerTeamId != Team1.TeamId && winnerTeamId != Team2.TeamId))
                throw new ArgumentException($"winnerTeamId is {winnerTeamId}, when it should be {Team1.TeamId} or {Team2.TeamId}");

            WinnerTeamId = winnerTeamId;

            _domainEvents.Add(new SeriesUpdatedEvent(this));
        }
        public void UpdateSeriesInfo(int numberOfMatches)
        {
            Info = SeriesInfo.Create(numberOfMatches);

            _domainEvents.Add(new SeriesUpdatedEvent(this));
        }
        public void AddSeriesMatch(SeriesMatch seriesMatch)
        {
            _seriesMatches.Add(seriesMatch);

            _domainEvents.Add(new SeriesMatchAddedEvent(this));
        }
        public void AddSeriesMatch(int leg,
            int matchId)
        {
            var seriesMatch = SeriesMatch.Create(leg,
                 matchId);

            _seriesMatches.Add(seriesMatch);

            _domainEvents.Add(new SeriesMatchAddedEvent(this));
        }

        public void UpdateSeriesMatchScores(int matchId, SeriesScore score1, SeriesScore score2)
        {
            var index = _seriesMatches.FindIndex(m => m.MatchId == matchId);
            _seriesMatches[index].UpdateSeriesMatchScore1(score1);
            _seriesMatches[index].UpdateSeriesMatchScore2(score2);

            _domainEvents.Add(new SeriesMatchUpdatedEvent(this));
        }

        public void UpdateSeriesMatchScore1(int matchId, SeriesScore score)
        {
            var index = _seriesMatches.FindIndex(m => m.MatchId == matchId);
            _seriesMatches[index].UpdateSeriesMatchScore1(score);

            _domainEvents.Add(new SeriesMatchUpdatedEvent(this));
        }

        public void UpdateSeriesMatchScore2(int matchId, SeriesScore score)
        {
            var index = _seriesMatches.FindIndex(m => m.MatchId == matchId);
            _seriesMatches[index].UpdateSeriesMatchScore2(score);

            _domainEvents.Add(new SeriesMatchUpdatedEvent(this));
        }

        public void AddSeriesMatches(IEnumerable<SeriesMatch> seriesMatches)
        {
            foreach (var seriesMatch in seriesMatches)
            {
                var existingSeriesMatch = _seriesMatches.FirstOrDefault(e => e.Id == seriesMatch.Id);
                if (existingSeriesMatch != null)
                {
                    throw new NotSupportedException("Existing series match updated. Not expected behavior.");
                }
                else
                {
                    _seriesMatches.Add(seriesMatch);
                }
            }
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
