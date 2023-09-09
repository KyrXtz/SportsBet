using SportsBet.Domain.Aggregates.MatchEvents;

namespace SportsBet.Domain.Aggregates.Matches
{
    public class Match : BaseEntity<int>, IAggregateRoot
    {
        public MatchName Name { get; private set; }
        public MatchBetContext BetContext { get; private set; }
        public MatchStatus Status { get; private set; }
        public MatchDate Date { get; private set; }
        public MatchParameters Parameters { get; private set; }
        public MatchCompetitors Competitors { get; private set; }
        public MatchScore Score { get; private set; }
        private List<MatchSpecialScore> _specialScore = new List<MatchSpecialScore>();
        public IReadOnlyCollection<MatchSpecialScore> SpecialScore => _specialScore.AsReadOnly();
        public int SportId { get; private set; }
        public int LeagueId { get; private set; }

        private List<MatchDetail> _details = new List<MatchDetail>(); 
        public IReadOnlyCollection<MatchDetail> Details => _details.AsReadOnly();

        private List<MatchLineupHome> _homeLineup = new List<MatchLineupHome>();
        public IReadOnlyCollection<MatchLineupHome> HomeLineup => _homeLineup.AsReadOnly();

        private List<MatchLineupAway> _awayLineup = new List<MatchLineupAway>();
        public IReadOnlyCollection<MatchLineupAway> AwayLineup => _awayLineup.AsReadOnly();

        private List<MatchStat> _stats = new List<MatchStat>();
        public IReadOnlyCollection<MatchStat> Stats => _stats.AsReadOnly();

        private List<MatchEvent> _matchEvents = new List<MatchEvent>();
        public IReadOnlyCollection<MatchEvent> MatchEvents => _matchEvents.AsReadOnly();

        private Match() { }

        internal Match(int id, 
            MatchName name,
            MatchStatus status,
            MatchDate date,
            MatchParameters parameters,
            MatchCompetitors competitors,
            MatchScore score,
            int sportId,
            int leagueId)
        {
            Id = Guard.Against.InvalidInput(id, nameof(id), id => id > 0);
            Name = name;
            Status = status;
            Date = date;
            Parameters = parameters;
            Competitors = competitors;
            Score = score;
            SportId = Guard.Against.InvalidInput(sportId, nameof(sportId), sportId => sportId > 0);
            LeagueId = Guard.Against.InvalidInput(leagueId, nameof(leagueId), leagueId => leagueId > 0);

            _domainEvents.Add(new MatchAddedEvent(this));
        }

        public static Match Create(int id,
            string name,
            MatchStatus status,
            DateTime gameStart,
            int homeCompetitorId,
            int awayCompetitorId,
            int sportId,
            int leagueId,
            int scoreHome = 0,
            int scoreAway = 0)
        {
            var matchName = MatchName.Create(name);
            var matchDate = MatchDate.Create(gameStart);
            var matchParameters = MatchParameters.Create();
            var matchCompetitors = MatchCompetitors.Create(homeCompetitorId, awayCompetitorId);

            var matchScore = MatchScore.Create(scoreHome, scoreAway);

            var match = new Match(id: id,
                name: matchName,
                status: status,
                date: matchDate,
                parameters: matchParameters,
                competitors: matchCompetitors,
                score: matchScore,
                sportId: sportId,
                leagueId: leagueId);

            return match;
        }

        public void Update(string name,
            MatchStatus status,
            DateTime gameStart,
            int homeCompetitorId,
            int awayCompetitorId)
        {
            var matchName = MatchName.Create(name);
            var matchDate = MatchDate.Create(gameStart);
            var matchParameters = MatchParameters.Create();
            var matchCompetitors = MatchCompetitors.Create(homeCompetitorId, awayCompetitorId);

            Name = matchName;
            Status = status;
            Date = matchDate;
            Parameters = matchParameters;
            Competitors = matchCompetitors;

            _domainEvents.Add(new MatchUpdatedEvent(this));
        }

        public void UpdateMatchName(MatchName name)
        {
            Name = name;

            _domainEvents.Add(new MatchUpdatedEvent(this));
        }

        public void UpdateMatchStatus(MatchStatus status)
        {
            Status = status;

            _domainEvents.Add(new MatchStatusChangedEvent(this));
        }

        public void UpdateMatchDate(MatchDate date)
        {
            Date = date;

            _domainEvents.Add(new MatchDateChangedEvent(this));
        }

        public void UpdateMatchParameters(MatchParameters parameters)
        {
            Parameters = parameters;

            _domainEvents.Add(new MatchUpdatedEvent(this));
        }

        public void UpdateMatchCompetitors(MatchCompetitors competitors)
        {
            Competitors = competitors;

            _domainEvents.Add(new MatchCompetitorsAddedOrUpdatedEvent(this));
        }

        public void AddMatchDetails(MatchDetail matchDetail)
        {
            _details.Add(matchDetail);

            _domainEvents.Add(new MatchDetailsAddedEvent(this));
        }

        public void AddMatchDetails(IEnumerable<MatchDetail> matchDetails)
        {
            _details.AddRange(matchDetails);

            _domainEvents.Add(new MatchDetailsAddedEvent(this));
        }

        public void AddOrUpdateLineup(IEnumerable<MatchLineup> lineups)
        {
            foreach (var lineup in lineups)
            {
                switch (lineup) {
                    case MatchLineupHome:
                        var homeLineup = lineup as MatchLineupHome;
                        if (_homeLineup.Any(l => l.PlayerId == lineup.PlayerId))
                            _homeLineup[_homeLineup.FindIndex(l => l.PlayerId == lineup.PlayerId)].UpdateLineupType(homeLineup.Type);
                        else _homeLineup.Add(homeLineup);
                        break;
                    case MatchLineupAway:
                        var awayLineup = lineup as MatchLineupAway;
                        if (_awayLineup.Any(l => l.PlayerId == lineup.PlayerId))
                            _awayLineup[_awayLineup.FindIndex(l => l.PlayerId == lineup.PlayerId)].UpdateLineupType(awayLineup.Type);
                        else _awayLineup.Add(awayLineup);
                        break;
                }                 
            }

            _domainEvents.Add(new MatchLineupAddedOrUpdatedEvent(this));
        }

        public void UpdateHomeLineupType(long lineupId, MatchLineupType type)
        {
            _homeLineup[_homeLineup.FindIndex(l => l.Id == lineupId)].UpdateLineupType(type);

            _domainEvents.Add(new MatchLineupTypeUpdatedEvent(this));
        }

        public void UpdateAwayLineupType(long lineupId, MatchLineupType type)
        {
            _awayLineup[_awayLineup.FindIndex(l => l.Id == lineupId)].UpdateLineupType(type);

            _domainEvents.Add(new MatchLineupTypeUpdatedEvent(this));
        }

        public void AddOrUpdateStats(IEnumerable<MatchStat> stats)
        {
            foreach (var stat in stats)
            {
                var existingStat = _stats.FirstOrDefault(p => p.Stat.EventId == stat.Stat.EventId &&
                    p.CompetitorId == stat.CompetitorId &&
                    p.PlayerId == stat.PlayerId);

                if (existingStat != null)
                {
                    var updatedStatValue = MatchStatValue.Create(stat.Stat.EventId, stat.Stat.Value);
                    if (!existingStat.Stat.Equals(updatedStatValue))
                    {
                        existingStat.UpdateStatValue(updatedStatValue);
                        existingStat.LastModifiedOn = DateTime.UtcNow;
                    }

                    if(existingStat.PlayerId != stat.PlayerId)
                    {
                        existingStat.UpdatePlayer(stat.PlayerId);
                        existingStat.LastModifiedOn = DateTime.UtcNow;
                    }
                }
                else
                {
                    var newStat = MatchStat.Create(eventId: stat.Stat.EventId,
                        value: stat.Stat.Value,
                        competitorId: stat.CompetitorId,
                        playerId: stat.PlayerId);

                    _stats.Add(newStat);
                }
            }

            _domainEvents.Add(new MatchStatAddedOrUpdatedEvent(this));
        }

        public void UpdateScore(int scoreHome, int scoreAway)
        {
            var matchScore = MatchScore.Create(scoreHome, scoreAway);
            Score = matchScore;

            _domainEvents.Add(new MatchScoreUpdatedEvent(this));
        }

        public void AddSpecialScore(Dictionary<int, int>? score)
        {
            var matchSpecialScore = new List<MatchSpecialScore>();
            matchSpecialScore.AddRange(score?.Select(s => MatchSpecialScore.Create(s.Key, s.Value)));

            _specialScore = matchSpecialScore;

            _domainEvents.Add(new MatchUpdatedEvent(this));
        }

        public void Map(int bBEventHistoryId, int mappingAgentId)
        {
            var matchBetContext = MatchBetContext.Create(bBEventHistoryId: bBEventHistoryId,
                mappingAgentId: mappingAgentId,
                mappedAt: DateTime.UtcNow);

            BetContext = matchBetContext;

            _domainEvents.Add(new MatchMappedEvent(this));
        }

        public void Unmap()
        {
            var matchBetContext = MatchBetContext.Create(bBEventHistoryId: null,
                mappingAgentId: null,
                mappedAt: null);

            BetContext = matchBetContext;

            _domainEvents.Add(new MatchUnmappedEvent(this));
        }
        public bool IsMapped()
        {
            return BetContext != null && BetContext.BBEventHistoryId != default;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
