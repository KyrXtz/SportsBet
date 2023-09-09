namespace SportsBet.Common.Requests;

#region XML

[Serializable, XmlRoot(ElementName = "match")]
public class MatchXml
{
	[XmlAttribute(AttributeName = "game_id")]
	public string GameId { get; set; }

	[XmlAttribute(AttributeName = "date")] 
	public string Date { get; set; }

	[XmlAttribute(AttributeName = "team1")]
	public string Team1 { get; set; }

	[XmlAttribute(AttributeName = "team1_id")]
	public string Team1Id { get; set; }

	[XmlAttribute(AttributeName = "team2")]
	public string Team2 { get; set; }

	[XmlAttribute(AttributeName = "team2_id")]
	public string Team2Id { get; set; }

	[XmlAttribute(AttributeName = "league")]
	public string League { get; set; }

	[XmlAttribute(AttributeName = "league_id")]
	public string LeagueId { get; set; }

	[XmlAttribute(AttributeName = "country1")]
	public string Country1 { get; set; }

	[XmlAttribute(AttributeName = "country1_id")]
	public string Country1Id { get; set; }

	[XmlAttribute(AttributeName = "country2")]
	public string Country2 { get; set; }

	[XmlAttribute(AttributeName = "country2_id")]
	public string Country2Id { get; set; }

	[XmlAttribute(AttributeName = "neutralvenue")]
	public string Neutralvenue { get; set; }

	[XmlAttribute(AttributeName = "stadium")]
	public string Stadium { get; set; }

	[XmlAttribute(AttributeName = "stadium_id")]
	public string StadiumId { get; set; }

	[XmlAttribute(AttributeName = "coverage")]
	public string Coverage { get; set; }

	[XmlAttribute(AttributeName = "coverage_id")]
	public string CoverageId { get; set; }

	[XmlAttribute(AttributeName = "playstate")]
	public string Playstate { get; set; }

	[XmlAttribute(AttributeName = "playstate_id")]
	public string PlaystateId { get; set; }

	[XmlAttribute(AttributeName = "scout_confirmed")]
	public string ScoutConfirmed { get; set; }

	[XmlAttribute(AttributeName = "league_country")]
	public string LeagueCountry { get; set; }

	[XmlAttribute(AttributeName = "league_country_id")]
	public string LeagueCountryId { get; set; }

	[XmlAttribute(AttributeName = "booked")]
	public string Booked { get; set; }

	[XmlAttribute(AttributeName = "iso")] 
	public string Iso { get; set; }

	[XmlAttribute(AttributeName = "odds_available")]
	public string OddsAvailable { get; set; }

	[XmlAttribute(AttributeName = "live_odds_available")]
	public string LiveOddsAvailable { get; set; }

	[XmlAttribute(AttributeName = "league_halftime_duration")]
	public string LeagueHalftimeDuration { get; set; }

	[XmlAttribute(AttributeName = "league_overtime_duration")]
	public string LeagueOvertimeDuration { get; set; }

	[XmlAttribute(AttributeName = "league_has_penalty_shootout")]
	public string LeagueHasPenaltyShootout { get; set; }

	[XmlAttribute(AttributeName = "league_has_player_data")]
	public string LeagueHasPlayerData { get; set; }

	[XmlAttribute(AttributeName = "sportId")]
	public string SportId { get; set; }

	[XmlAttribute(AttributeName = "sportname")]
	public string Sportname { get; set; }

	[XmlAttribute(AttributeName = "imported_game_id")]
	public string ImportedGameId { get; set; }

	[XmlAttribute(AttributeName = "imported_country1_id")]
	public string ImportedCountry1Id { get; set; }

	[XmlAttribute(AttributeName = "imported_country2_id")]
	public string ImportedCountry2Id { get; set; }

	[XmlAttribute(AttributeName = "imported_league_country_id")]
	public string ImportedLeagueCountryId { get; set; }

	[XmlAttribute(AttributeName = "imported_league_id")]
	public string ImportedLeagueId { get; set; }

	[XmlAttribute(AttributeName = "imported_stadium_id")]
	public string ImportedStadiumId { get; set; }

	[XmlAttribute(AttributeName = "imported_team1_id")]
	public string ImportedTeam1Id { get; set; }

	[XmlAttribute(AttributeName = "imported_team2_id")]
	public string ImportedTeam2Id { get; set; }

	[XmlAttribute(AttributeName = "leagueParameters")]
	public string LeagueParameters { get; set; }

	[XmlAttribute(AttributeName = "homeAdvantageId")]
	public string HomeAdvantageId { get; set; }

	[XmlAttribute(AttributeName = "homeAdvantage")]
	public string HomeAdvantage { get; set; }

	[XmlAttribute(AttributeName = "ticker_data")]
	public string Ticker_Dta { get; set; }

	[XmlElement(ElementName = "series")] public List<SeriesXml> Series { get; set; }
}

[Serializable, XmlRoot(ElementName = "seriesMatch")]
public class SeriesMatchXml
{
	[XmlAttribute(AttributeName = "leg")] 
	public string Leg { get; set; }
	
	[XmlAttribute(AttributeName = "date")] 
	public string Date { get; set; }

	[XmlAttribute(AttributeName = "team1_id")]
	public string Team1Id { get; set; }

	[XmlAttribute(AttributeName = "team2_id")]
	public string Team2Id { get; set; }

	[XmlAttribute(AttributeName = "playstate_id")]
	public string PlayStateId { get; set; }

	[XmlAttribute(AttributeName = "playstate")]
	public string PlayState { get; set; }

	[XmlAttribute(AttributeName = "game_id")]
	public string GameId { get; set; }

	[XmlAttribute(AttributeName = "winner_team_id")]
	public string WinnerId { get; set; }

	[XmlAttribute(AttributeName = "winner_team")]
	public string Winner { get; set; }

	[XmlAttribute(AttributeName = "score_team1")]
	public string ScoreTeam1 { get; set; }

	[XmlAttribute(AttributeName = "score_team2")]
	public string ScoreTeam2 { get; set; }

	[XmlAttribute(AttributeName = "standing_team1")]
	public string StandingTeam1 { get; set; }

	[XmlAttribute(AttributeName = "standing_team2")]
	public string StandingTeam2 { get; set; }
}

[Serializable, XmlRoot(ElementName = "series")]
public class SeriesXml
{
	[XmlElement(ElementName = "seriesMatch")]
	public List<SeriesMatchXml> SeriesMatches { get; set; }

	[XmlAttribute(AttributeName = "num_of_matches")]
	public string NumOfMatches { get; set; }

	[XmlAttribute(AttributeName = "team1_id")]
	public string Team1Id { get; set; }

	[XmlAttribute(AttributeName = "team2_id")]
	public string Team2Id { get; set; }

	[XmlAttribute(AttributeName = "score_team1")]
	public string ScoreTeam1 { get; set; }

    [XmlAttribute(AttributeName = "score_team2")]
    public string ScoreTeam2 { get; set; }

    [XmlAttribute(AttributeName = "winner_team_id")]
    public string WinnerTeamId { get; set; }
    [XmlAttribute(AttributeName = "standing_team1")]
    public string StandingTeam1 { get; set; }
    [XmlAttribute(AttributeName = "standing_team2")]
    public string StandingTeam2 { get; set; }

}

[Serializable, XmlRoot(ElementName = "match_list")]
public class GameListXmlRequest
{
	[XmlElement(ElementName = "match")] public List<MatchXml> Matches { get; set; }

	[XmlAttribute(AttributeName = "date_generated")]
	public string DateGenerated { get; set; }

	[XmlAttribute(AttributeName = "pusher_id")]
	public string PusherId { get; set; }
}

#endregion

#region JSON

public record GameListJsonRequest(
	[property: JsonProperty("match_list")] MatchListJson MatchList
);

    public record MatchJson(
        [property: JsonProperty("series")] List<SeriesJson> Series,
        [property: JsonProperty("game_id")] int GameId,
        [property: JsonProperty("date")] long Date,
        [property: JsonProperty("team1_id")] int Team1Id,
        [property: JsonProperty("team1")] string Team1,
        [property: JsonProperty("team2_id")] int Team2Id,
        [property: JsonProperty("team2")] string Team2,
        [property: JsonProperty("league_id")] int LeagueId,
        [property: JsonProperty("league")] string League,
        [property: JsonProperty("country1_id")] int Country1Id,
        [property: JsonProperty("country1")] string Country1,
        [property: JsonProperty("country2_id")] int Country2Id,
        [property: JsonProperty("country2")] string Country2,
        [property: JsonProperty("neutral venue")] bool NeutralVenue,
        [property: JsonProperty("stadium_id")] int StadiumId,
        [property: JsonProperty("stadium")] string Stadium,
        [property: JsonProperty("coverage_id")] int CoverageId,
        [property: JsonProperty("coverage")] string Coverage,
        [property: JsonProperty("playstate_id")] int PlaystateId,
        [property: JsonProperty("playstate")] string Playstate,
        [property: JsonProperty("scout_confirmed")] bool ScoutConfirmed,
        [property: JsonProperty("league_country_id")] int LeagueCountryId,
        [property: JsonProperty("league_country")] string LeagueCountry,
        [property: JsonProperty("booked")] bool Booked,
        [property: JsonProperty("iso")] string Iso,
        [property: JsonProperty("odds_available")] bool OddsAvailable,
        [property: JsonProperty("live_odds_available")] bool LiveOddsAvailable,
        [property: JsonProperty("homeAdvantageId")] int HomeAdvantageId,
        [property: JsonProperty("homeAdvantage")] string HomeAdvantage,
        [property: JsonProperty("league_halftime_duration")] int LeagueHalftimeDuration,
        [property: JsonProperty("league_overtime_duration")] int LeagueOvertimeDuration,
        [property: JsonProperty("league_has_penalty_shootout")] bool LeagueHasPenaltyShootOut,
        [property: JsonProperty("league_parameters")] string LeagueParameters,
        [property: JsonProperty("sportId")] int SportId,
        [property: JsonProperty("sportname")] string SportName,
        [property: JsonProperty("scout_id")] int ScoutId,
        [property: JsonProperty("scout_num_games")] int ScoutNumGames,
        [property: JsonProperty("scout_avg_ rating")] decimal ScoutAvgRating,
        [property: JsonProperty("scout_last10_avg_rating")] double ScoutLast10AvgRating,
        [property: JsonProperty("league_has_player_data")] bool LeagueHasPlayerData
    );

    public record MatchListJson(
        [property: JsonProperty("match")] List<MatchJson> Matches,
        [property: JsonProperty("date_generated")] long DateGenerated,
        [property: JsonProperty("pusher_id")] int PusherId
    );

public record SeriesJson(
        [property: JsonProperty("seriesMatch")] List<SeriesMatchJson> SeriesMatches,
        [property: JsonProperty("num_of_matches")] int NumOfMatches,
        [property: JsonProperty("team1_id")] int Team1Id,
        [property: JsonProperty("team2_id")] int Team2Id,
        [property: JsonProperty("score_team1")] int ScoreTeam1,
        [property: JsonProperty("score_team2")] int ScoreTeam2,
        [property: JsonProperty("winner_team_id")] int WinnerTeamId,
        [property: JsonProperty("standing_team1")] int StandingTeam1,
		[property: JsonProperty("standing_team2")] int StandingTeam2
    );

public record SeriesMatchJson(
	[property: JsonProperty("leg")] int Leg,
	[property: JsonProperty("date")] object Date,
	[property: JsonProperty("team1_id")] int? Team1Id,
	[property: JsonProperty("team2_id")] int Team2Id,
	[property: JsonProperty("playstate")] string PlayState,
	[property: JsonProperty("playstate_id")]int PlayStateId,
	[property: JsonProperty("winner_id")] int WinnerId,
	[property: JsonProperty("winner")] string Winner,
	[property: JsonProperty("game_id")] int GameId,
	[property: JsonProperty("score_team1")] int ScoreTeam1,
	[property: JsonProperty("score_team2")] int ScoreTeam2,
    [property: JsonProperty("standing_team1")] int StandingTeam1,
    [property: JsonProperty("standing_team2")] int StandingTeam2
);

#endregion