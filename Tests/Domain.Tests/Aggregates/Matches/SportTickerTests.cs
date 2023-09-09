using SportsBet.Domain.Aggregates.Matches;

namespace Domain.Tests.Aggregates.MatchTests
{
    [Collection("UniqueId Generator")]
    public class SportTickerTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        public SportTickerTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {

        }

        [Theory]
        [ClassData(typeof(MatchValidSeed))]
        public void Create_ValidParameters(
            int id,
            string name,
            MatchStatus status,
            DateTime gameStart,
            int homeCompetitorId,
            int awayCompetitorId,
            int sportId,
            int scoreHome = 0,
            int scoreAway = 0
            )
        {
            var match = new MatchBuilder()
                .WithId(id)
                .WithName(name)
                .WithStatus(status)
                .WithDate(gameStart)
                .WithCompetitors(homeCompetitorId, awayCompetitorId)
                .WithSportId(sportId)
                .WithScore(scoreHome, scoreAway)
                .Build();

            Assert.NotNull(match);
            Assert.Equal(id, match.Id);
            Assert.Equal(name, match.Name.Name);
            Assert.Equal(status, match.Status);
            Assert.Equal(gameStart, match.Date.GameStart);
            Assert.Equal(homeCompetitorId, match.Competitors.HomeCompetitorId);
            Assert.Equal(awayCompetitorId, match.Competitors.AwayCompetitorId);
            Assert.Equal(sportId, match.SportId);
            Assert.Equal(scoreHome, match.Score.ScoreHome);
            Assert.Equal(scoreAway, match.Score.ScoreAway);
        }

        [Theory]
        [ClassData(typeof(MatchInvalidSeed))]
        public void Create_InvalidParameters(
            int id,
            string name,
            MatchStatus status,
            DateTime gameStart,
            int homeCompetitorId,
            int awayCompetitorId,
            int sportId,
            int scoreHome = 0,
            int scoreAway = 0
            )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var match = new MatchBuilder()
                .WithId(id)
                .WithName(name)
                .WithStatus(status)
                .WithDate(gameStart)
                .WithCompetitors(homeCompetitorId, awayCompetitorId)
                .WithSportId(sportId)
                .WithScore(scoreHome, scoreAway)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateMatchValidSeed))]
        public void UpdateMatch_ValidParameters(
            string name,
            MatchStatus status,
            DateTime gameStart,
            int homeCompetitorId,
            int awayCompetitorId
           )
        {
            //Arrange
            var match = new MatchBuilder()
                .Build();

            //Act
            match.Update(name, status, gameStart, homeCompetitorId, awayCompetitorId);

            //Assert
            Assert.Equal(name, match.Name.Name);
            Assert.Equal(status, match.Status);
            Assert.Equal(gameStart, match.Date.GameStart);
            Assert.Equal(homeCompetitorId, match.Competitors.HomeCompetitorId);
            Assert.Equal(awayCompetitorId, match.Competitors.AwayCompetitorId);
        }

        [Theory]
        [ClassData(typeof(UpdateMatchInvalidSeed))]
        public void UpdateMatch_InvalidParameters(
            string name,
            MatchStatus status,
            DateTime gameStart,
            int homeCompetitorId,
            int awayCompetitorId
           )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var match = new MatchBuilder()
                .WithName(name)
                .WithStatus(status)
                .WithDate(gameStart)
                .WithCompetitors(homeCompetitorId, awayCompetitorId)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateMatchNameValidSeed))]
        public void UpdateMatchName_ValidParameters(
            string name
           )
        {
            //Arrange
            var match = new MatchBuilder()
                .Build();

            //Act
            var matchName = MatchName.Create(name);
            match.UpdateMatchName(matchName);

            //Assert
            Assert.Equal(name, match.Name.Name);
        }

        [Theory]
        [ClassData(typeof(UpdateMatchNameInvalidSeed))]
        public void UpdateMatchName_InvalidParameters(
            string name
           )
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var match = new MatchBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateMatchStatusValidSeed))]
        public void UpdateMatchStatus_ValidParameters(
            MatchStatus status
           )
        {
            //Arrange
            var match = new MatchBuilder()
                .Build();

            //Act
            match.UpdateMatchStatus(status);

            //Assert
            Assert.Equal(status.Name, match.Status.Name);
        }

        //todo check to see if we can test for invalid status
        //[Theory]
        //[ClassData(typeof(UpdateMatchStatusInvalidSeed))]
        //public void UpdateMatchStatus_InvalidParameters(
        //    MatchStatus status
        //   )
        //{
        //    Assert.ThrowsAny<ArgumentException>(() =>
        //    {
        //        var match = new MatchBuilder()
        //        .WithStatus(status)
        //        .Build();
        //    });
        //}

        [Theory]
        [ClassData(typeof(UpdateMatchDateValidSeed))]
        public void UpdateMatchDate_ValidParameters(
            DateTime date
           )
        {
            //Arrange
            var match = new MatchBuilder()
                .Build();

            //Act
            var matchDate = MatchDate.Create(date);
            match.UpdateMatchDate(matchDate);

            //Assert
            Assert.Equal(date, match.Date.GameStart);
        }

        //todo check to see if we can check for invalid datetime
        //[Theory]
        //[ClassData(typeof(UpdateMatchDateInvalidSeed))]
        //public void UpdateMatchDate_InvalidParameters(
        //    DateTime date
        //   )
        //{
        //    Assert.ThrowsAny<ArgumentException>(() =>
        //    {
        //        var match = new MatchBuilder()
        //        .WithDate(date)
        //        .Build();
        //    });
        //}


        [Theory]
        [ClassData(typeof(UpdateMatchCompetitorsValidSeed))]
        public void UpdateMatchCompetitors_ValidParameters(
            int homeCompetitorId,
            int awayCompetitorId
           )
        {
            //Arrange
            var match = new MatchBuilder()
                .Build();

            //Act
            var matchCompetitors = MatchCompetitors.Create(homeCompetitorId, awayCompetitorId);
            match.UpdateMatchCompetitors(matchCompetitors);

            //Assert
            Assert.Equal(homeCompetitorId, match.Competitors.HomeCompetitorId);
            Assert.Equal(awayCompetitorId, match.Competitors.AwayCompetitorId);

        }

        //todo check how to test for invalid
        //[Theory]
        //[ClassData(typeof(UpdateMatchCompetitorsInvalidSeed))]
        //public void UpdateMatchCompetitors_InvalidParameters(
        //    int homeCompetitorId,
        //    int awayCompetitorId
        //   )
        //{
        //    Assert.ThrowsAny<ArgumentException>(() =>
        //    {
        //        var match = new MatchBuilder()
        //        .WithCompetitors(homeCompetitorId, awayCompetitorId)
        //        .Build();
        //    });
        //}

        [Theory]
        [ClassData(typeof(AddMatchDetailsValidSeed))]
        public void AddMatchDetails_ValidParameters(
            int detailId,
            string typeId,
            string description,
            string value
           )
        {
            //Arrange
            var match = new MatchBuilder()
                .Build();

            //Act
            var matchDetails = MatchDetail.Create(detailId, typeId, description, value);
            match.AddMatchDetails(matchDetails);

            //Assert
            Assert.Equal(detailId, match.Details.ToList()[0].DetailId);
            Assert.Equal(typeId, match.Details.ToList()[0].TypeId);
            Assert.Equal(description, match.Details.ToList()[0].Description);
            Assert.Equal(value, match.Details.ToList()[0].Value);

        }

        [Theory]
        [ClassData(typeof(AddMatchDetailsInvalidSeed))]
        public void AddMatchDetails_InvalidParameters(
            int detailId,
            string typeId,
            string description,
            string value
           )
        {
            //todo is exception correct?
            Assert.ThrowsAny<Exception>(() =>
            {
                var match = new MatchBuilder()
                .WithDetail(detailId, typeId, description, value)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(AddOrUpdateLineupValidSeed))]
        public void AddOrUpdateLineup_ValidParameters(
            MatchLineupType type,
        int competitorId,
        int playerId,
        int sportId,
        bool isHome
           )
        {
            //Arrange
            var match = new MatchBuilder()
                .Build();

            //Act
            var matchLineups = new List<MatchLineup>();
            var matchLineup = MatchLineup.Create(type, competitorId, playerId, sportId, isHome);
            matchLineups.Add(matchLineup);

            match.AddOrUpdateLineup(matchLineups);

            //Assert
            Assert.Equal(type, match.HomeLineup.ToList()[0].Type);
            Assert.Equal(competitorId, match.HomeLineup.ToList()[0].CompetitorId);
            Assert.Equal(playerId, match.HomeLineup.ToList()[0].PlayerId);
            Assert.Equal(sportId, match.HomeLineup.ToList()[0].SportId);
            Assert.True(isHome);
        }

        //[Theory]
        //[ClassData(typeof(AddOrUpdateLineupInvalidSeed))]
        //public void AddOrUpdateLineup_InvalidParameters(
        //     MatchLineupType type,
        //    int competitorId,
        //    int playerId,
        //    int sportId
        //   )
        //{
        //    Assert.ThrowsAny<Exception>(() =>
        //    {
        //        var match = new MatchBuilder()
        //         .Build();

        //        var matchLineups = new List<MatchLineup>();
        //        //var matchLineup = MatchLineup.Create(type, competitorId, playerId, sportId);
        //    });
        //}


        [Theory]
        [ClassData(typeof(AddOrUpdateStatsValidSeed))]
        public void AddOrUpdateStats_ValidParameters(
           int eventId,
           string value,
           int competitorId,
           int? playerId
           )
        {
            //Arrange
            var match = new MatchBuilder()
                //.WithStat(eventId,value,competitorId,playerId)
                .Build();

            //Act
            var stats = new List<MatchStat>();
            MatchStat stat = MatchStat.Create(eventId, value, competitorId, playerId);
            stats.Add(stat);
            match.AddOrUpdateStats(stats);

            //Assert
            foreach (var singleStat in stats)
            {
                Assert.Equal(eventId, singleStat.Stat.EventId);
                Assert.Equal(value, singleStat.Stat.Value);
                Assert.Equal(competitorId, singleStat.CompetitorId);
                Assert.Equal(playerId, singleStat.PlayerId);
            }
        }

        [Theory]
        [ClassData(typeof(AddOrUpdateStatsInvalidSeed))]
        public void AddOrUpdateStats_InvalidParameters(
           int eventId,
           string value,
           int competitorId,
           int? playerId
           )
        {
            Assert.ThrowsAny<Exception>(() =>
            {
                var match = new MatchBuilder()
                    .Build();

                MatchStat stat = MatchStat.Create(eventId, value, competitorId, playerId);
            });
        }


        [Theory]
        [ClassData(typeof(UpdateScoreValidSeed))]
        public void UpdateScore_ValidParameters(
           int scoreHome,
           int scoreAway
           )
        {
            //Arrange
            var match = new MatchBuilder()
                .WithScore(scoreHome, scoreAway)
                .Build();

            //Act
            match.UpdateScore(scoreHome, scoreAway);

            //Assert

            Assert.Equal(scoreHome, match.Score.ScoreHome);
            Assert.Equal(scoreAway, match.Score.ScoreAway);
        }

        [Theory]
        [ClassData(typeof(MatchMapValidSeed))]
        public void MatchMapMap_ValidParameters(
        int bBCompetitionHistoryId,
        int mappingAgentId,
        DateTime dateTime)
        {
            var match = new MatchBuilder()
                .WithBetContext(bBCompetitionHistoryId, mappingAgentId, dateTime)
                .Build();

            match.Map(bBCompetitionHistoryId, mappingAgentId);

            Assert.NotNull(match);
            Assert.Equal(bBCompetitionHistoryId, match.BetContext.BBEventHistoryId);
            Assert.Equal(mappingAgentId, match.BetContext.MappingAgentId);
        }

        //[Theory]
        //[ClassData(typeof(MatchUnMapValidSeed))]
        //public void MatchMapUnmap_ValidParameters(
        //int bBCompetitionHistoryId,
        //int mappingAgentId,
        //DateTime dateTime)
        //{

        //    var match = new LeagueHistoryBuilder()
        //        .WithBetContext(bBCompetitionHistoryId, mappingAgentId, dateTime)
        //        .Build();


        //    match.Unmap();

        //    Assert.NotNull(match);
        //    Assert.Null(match.BetContext.BBCompetitionHistoryId);
        //    Assert.Null(match.BetContext.MappingAgentId);
        //}
    }
}
