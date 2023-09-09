namespace SportsBet.Application.Commands.GameList;

class GameListCommandHandler : IRequestHandler<GameListCommand, Result<Unit>>
{
	private readonly IRepository<League> _leagueRepository;
	private readonly IFeedQueuePublisher<CreateUpdateMatchsCommand> _matchsPublisher;
	private readonly IFeedQueuePublisher<CreateUpdateSeriesCommand> _seriesPublisher;

	public GameListCommandHandler(IRepository<League> leagueRepository,
		IFeedQueuePublisher<CreateUpdateMatchsCommand> matchsPublisher,
		IFeedQueuePublisher<CreateUpdateSeriesCommand> seriesPublisher)
	{
		_leagueRepository = leagueRepository;
		_matchsPublisher = matchsPublisher;
		_seriesPublisher = seriesPublisher;
	}

	public async Task<Result<Unit>> Handle(GameListCommand request, CancellationToken cancellationToken)
	{
		var matchList = request.Payload.MatchList.Matches.DistinctBy(m => m.GameId).ToList();
		var leagueIds = matchList.Select(m => m.LeagueId).ToArray();
		var existingLeagues = await _leagueRepository.ListAsync(new GetLeaguesByIdsSpecification(leagueIds));
		matchList.RemoveAll(m =>
		   !existingLeagues.Any(l => l.Id == m.LeagueId));

		var matchItems = matchList.Select(e => new MatchItem
		{
			Id = e.GameId,
			Name = e.Team1 + " - " + e.Team2,
			SportId = e.SportId,
			LeagueId = e.LeagueId,
			Date = e.Date,
			Status = e.PlayStateId,
			HomeCompetitorId = e.Team1Id,
			AwayCompetitorId = e.Team2Id
		});

		if (matchItems.Any())
		{
			var groupedSportTickerItems = matchItems.GroupBy(s => s.Id);
			foreach (var group in groupedSportTickerItems)
			{
				var singleSportTickerItems = group.AsEnumerable();
				var partitionedQueueMessageKey = group.Key;
				var command = new CreateUpdateMatchsCommand(singleSportTickerItems);

				await _matchsPublisher.Publish(partitionedQueueMessageKey, command);
			}
		}

		//Ignore series that have MatchId = 0
		//We expect them to come in later messages
		var series = request.Payload.MatchList.Matches
			.SelectMany(m => m.Series)
			.Where(s => !s.SeriesMatches.Any(sm => sm.GameId == 0))
			.ToList();

		var seriesItems = new List<SeriesItem>();
		foreach (var s in series)
		{
			seriesItems.Add(new SeriesItem
			{
				NumberOfMatches = s.NumOfMatches,
				Team1Id = s.Team1Id,
				Team1Score = s.ScoreTeam1,
				Team1Standing = s.StandingTeam1,
				Team2Id = s.Team2Id,
				Team2Score = s.ScoreTeam2,
				Team2Standing = s.StandingTeam2,
				WinnerTeamId = s.WinnerTeamId,
				SeriesMatches = s.SeriesMatches.Select(sm => new SeriesItem.SeriesMatchItem
				{
					Leg = sm.Leg,
					MatchId = sm.GameId,
					Score1 = sm.ScoreTeam1,
					Score2 = sm.ScoreTeam2,
					Standing1 = sm.StandingTeam1,
					Standing2 = sm.StandingTeam2
				}).ToList()
			});
		}

		if (seriesItems.Any())
		{
			var partitionedQueueMessageKey = UniqueIdGenerator.CreateId();
			var command = new CreateUpdateSeriesCommand(seriesItems);

			await _seriesPublisher.Publish(partitionedQueueMessageKey, command);
		}

		return Result<Unit>.Success();
	}
}