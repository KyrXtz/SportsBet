namespace Domain.Tests.Aggregates.Series
{
    [Collection("UniqueId Generator")]
    public class SeriesTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public SeriesTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition) { }
        
        [Theory]
        [ClassData(typeof(SeriesValidSeed))]
        public void Create_ValidParameters(
            int id,
            int numberOfMatches,
            int teamOneId,
            int teamOneScore,
            int teamOneStanding,
            int teamTwoId,
            int teamTwoScore,
            int teamTwoStanding,
            int winnerTeamId
            )
        {
            var series = new SeriesBuilder()
                .WithId(id)
                .WithSeriesInfo(numberOfMatches)
                .WithSeriesTeamOne(teamOneId)
                .WithSeriesScoreOne(teamOneScore, teamOneStanding)
                .WithSeriesTeamTwo(teamTwoId)
                .WithSeriesScoreTwo(teamTwoScore, teamTwoStanding)
                .WithWinnerTeamId(winnerTeamId)
                .Build();

            Assert.NotNull(series);
            Assert.Equal(numberOfMatches, series.Info.NumberOfMatches);
            Assert.Equal(teamOneId, series.Team1.TeamId);
            Assert.Equal(teamOneScore, series.Team1.Score.Score);
            Assert.Equal(teamOneStanding, series.Team1.Score.Standing);
            Assert.Equal(teamTwoId, series.Team2.TeamId);
            Assert.Equal(teamTwoScore, series.Team2.Score.Score);
            Assert.Equal(teamTwoStanding, series.Team2.Score.Standing);
            Assert.Equal(winnerTeamId, series.WinnerTeamId);
        }

        [Theory]
        [ClassData(typeof(SeriesInvalidSeed))]
        public void Create_InvalidParameters(
            int id,
            int numberOfMatches,
            int teamOneId,
            int teamOneScore,
            int teamOneStanding,
            int teamTwoId,
            int teamTwoScore,
            int teamTwoStanding,
            int winnerTeamId
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .WithId(id)
                    .WithSeriesInfo(numberOfMatches)
                    .WithSeriesTeamOne(teamOneId)
                    .WithSeriesScoreOne(teamOneScore, teamOneStanding)
                    .WithSeriesTeamTwo(teamTwoId)
                    .WithSeriesScoreTwo(teamTwoScore, teamTwoStanding)
                    .WithWinnerTeamId(winnerTeamId)
                    .Build();
            });
        }
        
        [Theory]
        [ClassData(typeof(UpdateSeriesValidSeed))]
        public void UpdateSeries_ValidParameters(
            int teamOneId,
            int teamOneScore,
            int teamOneStanding,
            int teamTwoId,
            int teamTwoScore,
            int teamTwoStanding,
            int winnerTeamId
            )
        {
            //Arrange
            var series = new SeriesBuilder()
                .Build();

            var seriesOneScore = SeriesScore.Create(teamOneScore, teamOneStanding);
            var seriesTeamOne = SeriesTeam.Create(teamOneId, seriesOneScore);

            var seriesTwoScore = SeriesScore.Create(teamTwoScore, teamTwoStanding);
            var seriesTeamTwo = SeriesTeam.Create(teamTwoId, seriesTwoScore);

            //Act
            series.Update(seriesTeamOne, seriesTeamTwo, winnerTeamId);

            //Assert
            Assert.Equal(seriesTeamOne, series.Team1);
            Assert.Equal(seriesTeamTwo, series.Team2);
            Assert.Equal(winnerTeamId, series.WinnerTeamId);
        }

        [Theory]
        [ClassData(typeof(UpdateSeriesInValidSeed))]
        public void UpdateSport_InvalidParameters(
            int teamOneId,
            int teamOneScore,
            int teamOneStanding,
            int teamTwoId,
            int teamTwoScore,
            int teamTwoStanding,
            int winnerTeamId
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .WithSeriesTeamOne(teamOneId)
                    .WithSeriesScoreOne(teamOneScore, teamOneStanding)
                    .WithSeriesTeamTwo(teamTwoId)
                    .WithSeriesScoreTwo(teamTwoScore, teamTwoStanding)
                    .WithWinnerTeamId(winnerTeamId)
                    .Build();
            });
        }

        [Theory]
        [ClassData(typeof(CreateUpdateTeamOneSeriesValidSeed))]
        public void CreateUpdateTeamOneSeries_ValidParameters(int teamOneId)
        {
            //Arrange
            var series = new SeriesBuilder()
                .Build();

            //Act
            series.CreateUpdateTeam1(teamOneId);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(teamOneId, series.Team1.TeamId);
        }

        [Theory]
        [ClassData(typeof(CreateUpdateTeamOneSeriesInValidSeed))]
        public void CreateUpdateTeamOneSeries_InValidParameters(int teamOneId)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .WithSeriesTeamOne(teamOneId)
                    .Build();
            }); 
        }

        [Theory]
        [ClassData(typeof(CreateUpdateTeamTwoSeriesValidSeed))]
        public void CreateUpdateTeamTwoSeries_ValidParameters(int teamTwoId)
        {
            //Arrange
            var series = new SeriesBuilder()
                .Build();

            //Act
            series.CreateUpdateTeam1(teamTwoId);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(teamTwoId, series.Team1.TeamId);
        }

        [Theory]
        [ClassData(typeof(CreateUpdateTeamTwoSeriesInValidSeed))]
        public void CreateUpdateTeamTwoSeries_InValidParameters(int teamTwoId)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .WithSeriesTeamOne(teamTwoId)
                    .Build();
            });
        }

        [Theory]
        [ClassData(typeof(CreateUpdateScoreOneSeriesValidSeed))]
        public void CreateUpdateScoreOneSeries_ValidParameters(int teamOneScore, int teamOneStanding)
        {
            //Arrange
            var series = new SeriesBuilder()
                .Build();

            var seriesOneScore = SeriesScore.Create(teamOneScore, teamOneStanding);

            //Act
            series.CreateUpdateScore1(seriesOneScore);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(teamOneScore, seriesOneScore.Score);
            Assert.Equal(teamOneStanding, seriesOneScore.Standing);
        }

        [Theory]
        [ClassData(typeof(CreateUpdateScoreOneSeriesInValidSeed))]
        public void CreateUpdateScoreOneSeries_InValidParameters(int teamOneScore, int teamOneStanding)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .WithSeriesScoreOne(teamOneScore, teamOneStanding)
                    .Build(); 
            });
        }

        [Theory]
        [ClassData(typeof(CreateUpdateScoreTwoSeriesValidSeed))]
        public void CreateUpdateScoreTwoSeries_ValidParameters(int teamTwoScore, int teamTwoStanding)
        {
            //Arrange
            var series = new SeriesBuilder()
                .Build();

            var seriesTwoScore = SeriesScore.Create(teamTwoScore, teamTwoStanding);

            //Act
            series.CreateUpdateScore1(seriesTwoScore);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(teamTwoScore, seriesTwoScore.Score);
            Assert.Equal(teamTwoStanding, seriesTwoScore.Standing);
        }

        [Theory]
        [ClassData(typeof(CreateUpdateScoreTwoSeriesInValidSeed))]
        public void CreateUpdateScoreTwoSeries_InValidParameters(int teamTwoScore, int teamTwoStanding)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .WithSeriesScoreOne(teamTwoScore, teamTwoStanding)
                    .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateWinnerSeriesValidSeed))]
        public void UpdateWinnerSeries_ValidParameters(int team1Id, int winnerTeamId)
        {
            //Arrange
            var series = new SeriesBuilder()
                .WithSeriesTeamOne(team1Id)
                .Build();

            //Act
            series.UpdateWinner(winnerTeamId);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(winnerTeamId, series.WinnerTeamId);
        }

        [Theory]
        [ClassData(typeof(UpdateWinnerSeriesInValidSeed))]
        public void UpdateWinnerSeries_InValidParameters(int winnerTeamId)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .Build();

                series.UpdateWinner(winnerTeamId);
            });
        }

        [Theory]
        [ClassData(typeof(UpdateSeriesInfoValidSeed))]
        public void UpdateSeriesInfo_ValidParameters(int numberOfMatches)
        {
            //Arrange
            var series = new SeriesBuilder()
                .Build();

            //Act
            series.UpdateSeriesInfo(numberOfMatches);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(numberOfMatches, series.Info.NumberOfMatches);
        }

        [Theory]
        [ClassData(typeof(UpdateSeriesInfoInValidSeed))]
        public void UpdateSeriesInfo_InValidParameters(int numberOfMatches)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .WithSeriesInfo(numberOfMatches)
                    .Build(); 
            });
        }

        [Theory]
        [ClassData(typeof(AddSeriesMatchValidSeed))]
        public void AddSeriesMatch_ValidParameters(int leg, int matchId)
        {
            //Arrange
            var series = new SeriesBuilder()
                .WithSeriesMatch(leg, matchId)
                .Build();

            series.AddSeriesMatch(leg, matchId);

            //Assert
            Assert.NotNull(series);
            foreach (var serieMatch in series.SeriesMatches)
            {
                Assert.Equal(leg, serieMatch.Leg);
                Assert.Equal(matchId, serieMatch.MatchId);
            }
            
        }

        [Theory]
        [ClassData(typeof(AddSeriesMatchInValidSeed))]
        public void AddSeriesMatch_InValidParameters(int leg, int matchId)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                    .WithSeriesMatch(leg, matchId)
                    .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateSeriesMatchScoresValidSeed))]
        public void UpdateSeriesMatchScores_ValidParameters(
            int scoreOne,
            int StandingOne,
            int scoreTwo,
            int StandingTwo,
            int leg,
            int matchId
            )
        {
            //Arrange
            var series = new SeriesBuilder()
                .WithSeriesScoreOne(scoreOne, StandingOne)
                .WithSeriesScoreTwo(scoreTwo, StandingTwo)
                .WithSeriesMatch(leg, matchId)
                .Build();

            var seriesOneScore = SeriesScore.Create(scoreOne, StandingOne);
            var seriesTwoScore = SeriesScore.Create(scoreTwo, StandingTwo);

            series.UpdateSeriesMatchScores(series.SeriesMatches.ToList()[0].MatchId, seriesOneScore, seriesTwoScore);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(scoreOne, series.Team1.Score.Score);
            Assert.Equal(StandingOne, series.Team1.Score.Standing);
            Assert.Equal(scoreTwo, series.Team1.Score.Score);
            Assert.Equal(StandingTwo, series.Team1.Score.Standing);

        }

        [Theory]
        [ClassData(typeof(UpdateSeriesMatchScoresInValidSeed))]
        public void UpdateSeriesMatchScores_InValidParameters(
            int scoreOne,
            int StandingOne,
            int scoreTwo,
            int StandingTwo,
            int leg,
            int matchId
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                .WithSeriesScoreOne(scoreOne, StandingOne)
                .WithSeriesScoreTwo(scoreTwo, StandingTwo)
                .WithSeriesMatch(leg, matchId)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateSeriesMatchScore1ValidSeed))]
        public void UpdateSeriesMatchScore1_ValidParameters(
            int scoreOne,
            int StandingOne,
            int leg,
            int matchId
            )
        {
            //Arrange
            var series = new SeriesBuilder()
                .WithSeriesScoreOne(scoreOne, StandingOne)
                .WithSeriesMatch(leg, matchId)
                .Build();

            var seriesOneScore = SeriesScore.Create(scoreOne, StandingOne);

            series.UpdateSeriesMatchScore1(series.SeriesMatches.ToList()[0].MatchId, seriesOneScore);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(seriesOneScore, series.SeriesMatches.ToList()[0].Score1);
        }

        [Theory]
        [ClassData(typeof(UpdateSeriesMatchScore1InValidSeed))]
        public void UpdateSeriesMatchScore1_InValidParameters(
            int scoreOne,
            int StandingOne,
            int leg,
            int matchId
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                .WithSeriesScoreOne(scoreOne, StandingOne)
                .WithSeriesMatch(leg, matchId)
                .Build();
            });
        }
        
        [Theory]
        [ClassData(typeof(UpdateSeriesMatchScore2ValidSeed))]
        public void UpdateSeriesMatchScore2_ValidParameters(
            int scoreTwo,
            int StandingTwo,
            int leg,
            int matchId
            )
        {
            //Arrange
            var series = new SeriesBuilder()
                .WithSeriesScoreTwo(scoreTwo, StandingTwo)
                .WithSeriesMatch(leg, matchId)
                .Build();

            var seriesTwoScore = SeriesScore.Create(scoreTwo, StandingTwo);

            series.UpdateSeriesMatchScore2(series.SeriesMatches.ToList()[0].MatchId, seriesTwoScore);

            //Assert
            Assert.NotNull(series);
            Assert.Equal(seriesTwoScore, series.SeriesMatches.ToList()[0].Score2);
        }

        [Theory]
        [ClassData(typeof(UpdateSeriesMatchScore2InValidSeed))]
        public void UpdateSeriesMatchScore2_InValidParameters(
            int scoreTwo,
            int StandingTwo,
            int leg,
            int matchId
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                .WithSeriesScoreTwo(scoreTwo, StandingTwo)
                .WithSeriesMatch(leg, matchId)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(AddOrUpdateSeriesMatchesValidSeed))]
        public void AddOrUpdateSeriesMatches_ValidParameters(int leg, int matchId)
        {
            //Arrange
            var series = new SeriesBuilder()
                .Build();

            var seriesMatch = SeriesMatch.Create(leg, matchId);
            series.AddSeriesMatches(new List<SeriesMatch> { seriesMatch });

            //Assert
            Assert.NotNull(series);
            Assert.Equal(matchId, series.SeriesMatches.ToList()[0].MatchId);
        }

        [Theory]
        [ClassData(typeof(AddOrUpdateSeriesMatchesInValidSeed))]
        public void AddOrUpdateSeriesMatches_InValidParameters(int leg, int matchId)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var series = new SeriesBuilder()
                .WithSeriesMatch(leg, matchId)
                .Build();
            });
        }
    }
}
