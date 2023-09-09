namespace SportsBet.Application.Commands.Series;

using Series = Domain.Aggregates.Series.Series;
class CreateUpdateSeriesCommandHandler : IRequestHandler<CreateUpdateSeriesCommand, Result<List<long>>>
{
    private readonly IRepository<Series> _repository;

    public CreateUpdateSeriesCommandHandler(IRepository<Series> repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<long>>> Handle(CreateUpdateSeriesCommand request, CancellationToken cancellationToken)
    {
        var seriesMatchesIds = request.Series.SelectMany(s => s.SeriesMatches).Select(sm => sm.MatchId).ToArray();

        var existingSeries = await _repository.ListAsync(new GetSeriesByMatchIdsSpecification(seriesMatchesIds,true));

        var newSeries = new List<Series>();
        var upSeries = new List<Series>();

        foreach (var series in request.Series)
        {
            var singularSeriesMatchesIds = series.SeriesMatches.Select(sm => sm.MatchId);
            var existingSingularSeries = existingSeries
                .FirstOrDefault(s => s.SeriesMatches.Any(sm => singularSeriesMatchesIds.Contains(sm.MatchId)));
                
            if (existingSingularSeries != null)
            {
                var seriesInfo = SeriesInfo.Create(numberOfMatches: series.NumberOfMatches);

                if (!existingSingularSeries.Info.Equals(seriesInfo.NumberOfMatches))
                {
                    existingSingularSeries.UpdateSeriesInfo(seriesInfo.NumberOfMatches);
                    upSeries.AddUniqueItem(existingSingularSeries);
                }

                if (!existingSingularSeries.WinnerTeamId.Equals(series.WinnerTeamId))
                {
                    existingSingularSeries.UpdateWinner(series.WinnerTeamId);
                    upSeries.AddUniqueItem(existingSingularSeries);
                }

                if (!existingSingularSeries.Team1.TeamId.Equals(series.Team1Id))
                {
                    existingSingularSeries.CreateUpdateTeam1(series.Team1Id);
                    upSeries.AddUniqueItem(existingSingularSeries);
                }

                if (!existingSingularSeries.Team2.TeamId.Equals(series.Team2Id))
                {
                    existingSingularSeries.CreateUpdateTeam2(series.Team2Id);
                    upSeries.AddUniqueItem(existingSingularSeries);
                }

                if (!existingSingularSeries.Team1.Score.Equals(series.Team1Score))
                {
                    var teamScore = SeriesScore.Create(series.Team1Id, series.Team1Score);
                    existingSingularSeries.CreateUpdateScore1(teamScore);
                    upSeries.AddUniqueItem(existingSingularSeries);
                }

                if (!existingSingularSeries.Team2.Score.Equals(series.Team2Score))
                {
                    var teamScore = SeriesScore.Create(series.Team2Id, series.Team2Score);
                    existingSingularSeries.CreateUpdateScore2(teamScore);
                    upSeries.AddUniqueItem(existingSingularSeries);
                }

                var seriesMatches = series.SeriesMatches.Select(sm => SeriesMatch.Create(sm.Leg, sm.MatchId));

                existingSingularSeries.AddSeriesMatches(seriesMatches);

                series.SeriesMatches.ForEach(sm =>
                {
                    var score1 = SeriesScore.Create(sm.Score1, sm.Standing1);
                    var score2 = SeriesScore.Create(sm.Score1, sm.Standing1);
                    existingSingularSeries.UpdateSeriesMatchScores(sm.MatchId, score1, score2);
                });

                continue;
            }

            var newSingularSeries = Series.Create(
                    numberOfMatches: series.NumberOfMatches,
                    teamOneId: series.Team1Id,
                    teamOneScore: series.Team1Score,
                    teamOneStanding: series.Team1Standing,
                    teamTwoId: series.Team2Id,
                    teamTwoScore: series.Team2Score,
                    teamTwoStanding: series.Team2Standing,
                    winnerTeamId: series.WinnerTeamId);

            var newSeriesMatches = series.SeriesMatches.Select(sm => SeriesMatch.Create(sm.Leg, sm.MatchId));

            newSingularSeries.AddSeriesMatches(newSeriesMatches);

            series.SeriesMatches.ForEach(sm =>
            {
                var score1 = SeriesScore.Create(sm.Score1, sm.Standing1);
                var score2 = SeriesScore.Create(sm.Score1, sm.Standing1);
                newSingularSeries.UpdateSeriesMatchScores(sm.MatchId, score1, score2);
            });

            newSeries.Add(newSingularSeries);
        }

        if (!newSeries.Any() && !upSeries.Any())
            return Result<List<long>>.Fail();

        var returnList = new List<long>();

        if (newSeries.Any())
        {
            await _repository.AddRangeAsync(newSeries);
            returnList.AddRange(newSeries.Select(p => p.Id).ToList());
        }

        if (upSeries.Any())
        {
            await _repository.UpdateRangeAsync(upSeries);
            returnList.AddRange(upSeries.Select(p => p.Id).ToList());
        }

        return Result<List<long>>.Success(returnList);
    }
}
