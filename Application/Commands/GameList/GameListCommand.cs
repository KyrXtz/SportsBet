namespace SportsBet.Application.Commands.GameList;

public class GameListCommand : Webhook
{
    public GameListPayload Payload { get; private set; }
    private GameListCommand() { }

    public GameListCommand(GameListPayload payload)
    {
        Payload = payload;
    }
}

#region Payload Records

public record GameListPayload(MatchList MatchList)
{
    public GameListPayload() : this(new MatchList(new List<Match>(), DateTime.UtcNow, 0))
    {
    }
}

public record MatchList(
    IReadOnlyList<Match> Matches,
    DateTime DateGenerated,
    int PusherId
)
{
    public MatchList() : this(new List<Match>(), DateTime.UtcNow, 0)
    {
    }
}

public record Match(
    IReadOnlyList<SeriesList> Series,
    int GameId,
    DateTime Date,
    int Team1Id,
    string Team1,
    int Team2Id,
    string Team2,
    int LeagueId,
    string League,
    int Country1Id,
    string Country1,
    int Country2Id,
    string Country2,
    bool NeutralVenue,
    int StadiumId,
    string Stadium,
    int CoverageId,
    string Coverage,
    int PlayStateId,
    string PlayState,
    bool ScoutConfirmed,
    int LeagueCountryId,
    string LeagueCountry,
    bool Booked,
    string Iso,
    bool OddsAvailable,
    bool LiveOddsAvailable,
    int HomeAdvantageId,
    string HomeAdvantage,
    int LeagueHalftimeDuration,
    int LeagueOvertimeDuration,
    bool LeagueHasPenaltyShootOut,
    bool LeagueHasPlayerData,
    string LeagueParameters,
    int SportId,
    string SportName,
    int ScoutId,
    int ScoutNumGames,
    decimal ScoutAvgRating,
    double ScoutLast10AvgRating)
{
    public Match() : this(new List<SeriesList>(), default, DateTime.UtcNow, default, string.Empty, default,
        string.Empty, default, string.Empty,
        default, string.Empty, default, string.Empty, false, default, string.Empty, default, string.Empty, default,
        string.Empty,
        false, default, string.Empty, false, string.Empty, false, false, default, string.Empty, default, default, false,
        false, string.Empty, default,
        string.Empty, default, default, default, default)
    {
    }
}

public record SeriesList(
    IReadOnlyList<SeriesListMatch> SeriesMatches,
    int NumOfMatches,
    int Team1Id,
    int Team2Id,
    int ScoreTeam1,
    int ScoreTeam2,
    int WinnerTeamId,
    int StandingTeam1,
    int StandingTeam2
)
{
    public SeriesList() : this(new List<SeriesListMatch>(), default, default, default, default, default, default,
        default, default)
    {
    }
}

public record SeriesListMatch(
    int Leg,
    DateTime Date,
    int Team1Id,
    int Team2Id,
    string PlayState,
    int PlayStateId,
    int WinnerId,
    string Winner,
    int GameId,
    int ScoreTeam1,
    int ScoreTeam2,
    int StandingTeam1,
    int StandingTeam2
)
{
    public SeriesListMatch() : this(default, DateTime.UtcNow, default, default, string.Empty, default, default,
        string.Empty, default, default, default, default, default)
    {
    }
}
#endregion