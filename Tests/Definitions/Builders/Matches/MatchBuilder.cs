using Match = SportsBet.Domain.Aggregates.Matches.Match;

public class MatchBuilder
{
    private int id = 1;
    private string name = "MatchName";
    private MatchStatus status = MatchStatus.Suspended;
    private DateTime date = DateTime.Now;
    private MatchParameters parameters = MatchParameters.Create();
    private int homeCompetitorId = 1;
    private int awayCompetitorId = 2;
    private int scoreHome = 1;
    private int scoreAway = 2;
    private MatchDetail detail;
    private int detailId;
    private string typeId;
    private string description;
    private int value = 1;
    private int sportId = 1;
    private int leagueId = 1;
    private MatchBetContext betContext;

    public Match Build()
    {
        var match = Match.Create(id, name, status, date, homeCompetitorId, awayCompetitorId, sportId, leagueId);
        return match;
    }

    public MatchBuilder WithId(int id)
    {
        this.id = id;
        return this;
    }

    public MatchBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }

    public MatchBuilder WithStatus(MatchStatus status)
    {
        this.status = status;
        return this;
    }
    //public MatchBuilder WithMatchStatus(int value)
    //{
    //    this.value = value;
    //    return this;
    //}

    public MatchBuilder WithDate(DateTime date)
    {
        this.date = date;
        return this;
    }

    public MatchBuilder WithParameters(MatchParameters parameters)
    {
        this.parameters = parameters;
        return this;
    }

    public MatchBuilder WithCompetitors(int homeCompetitorId, int awayCompetitorId)
    {
        this.homeCompetitorId = homeCompetitorId;
        this.awayCompetitorId = awayCompetitorId;
        return this;
    }

    public MatchBuilder WithScore(int scoreHome, int scoreAway)
    {
        this.scoreHome = scoreHome;
        this.scoreAway = scoreAway;
        return this;
    }

    public MatchBuilder WithSportId(int sportId)
    {
        this.sportId = sportId;
        return this;
    }
    public MatchBuilder WithLeagueId(int leagueId)
    {
        this.leagueId = leagueId;
        return this;
    }
    public MatchBuilder WithDetail(int detailId,string typeId,string description,string value)
    {
        var detail = MatchDetail.Create(detailId, typeId, description, value);
        this.detail = detail;
        return this;
    }

    public MatchBuilder WithBetContext(int? bBCompetitionHistoryId, int? mappingAgentId, DateTime? dateTime)
    {
        this.betContext = new MatchBetContext(bBCompetitionHistoryId, mappingAgentId, dateTime);
        return this;
    }

    public MatchBuilder WithHomeLineup(MatchLineupType homeLineUpType,int competitorId,int playerId,int sportId)
    {
        //var homeLineUp = MatchLineup.Create(homeLineUpType, competitorId,playerId,sportId);
        //this.homeLineup = homeLineUp;
        return this;
    }

    public MatchBuilder WithAwayLineup(MatchLineupType awayLineUpType, int competitorId, int playerId, int sportId)
    {
        //var awayLineup = MatchLineup.Create(awayLineUpType, competitorId, playerId, sportId);
        //this.awayLineup = awayLineup;
        return this;
    }

    public MatchBuilder WithStat(int eventId,
            string value,
            int competitorId,
            int? playerId)
    {
        var stat = MatchStat.Create(eventId,
            value,
            competitorId,
            playerId);
        //this.stat = stat;

        return this;
    }

    public MatchBuilder WithEvent(int eventId, int eventNumber, string eventCode, MatchState state, int minute, long timeStamp, DateTime date, int matchId, bool? clockRunning)
    {
        var tickerEvent = MatchEvent.Create(eventId, eventNumber, eventCode, state, minute, timeStamp, date, matchId, clockRunning);
        //this.tickerEvent = tickerEvent;
        return this;
    }

    public static implicit operator Match(MatchBuilder instance)
    {
        return instance.Build();
    }
}

