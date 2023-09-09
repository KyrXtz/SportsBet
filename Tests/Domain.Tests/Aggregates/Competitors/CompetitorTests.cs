namespace Domain.Tests.Aggregates.Competitors
{
    public class CompetitorTests
    {
        [Theory]
        [ClassData(typeof(CompetitorValidSeed))]
        public void Create_ValidParameters(string name)
        {
            var competitor = new CompetitorBuilder()
                .WithName(name)
                .Build();

            Assert.NotNull(competitor);
            Assert.Equal(name, competitor.CompetitorName.Name);
        }

        [Theory]
        [ClassData(typeof(CompetitorInvalidSeed))]
        public void Create_InvalidParameters(int id, string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var competitor = new CompetitorBuilder()
                    .WithId(id)
                    .WithName(name)
                    .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateCompetitorValidSeed))]
        public void UpdateCompetitor_ValidParameters(string name)
        {
            //Arrange
            var competitor = new CompetitorBuilder()
                .Build();

            //Act
            competitor.Update(name);

            //Assert
            Assert.Equal(name, competitor.CompetitorName.Name);
        }

        [Theory]
        [ClassData(typeof(UpdateCompetitorInvalidSeed))]
        public void Updatecompetitor_InvalidParameters(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var competitor = new CompetitorBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateCompetitorNameValidSeed))]
        public void UpdateCompetitorName_ValidParameters(string name)
        {
            //Arrange
            var competitor = new CompetitorBuilder()
                .Build();

            var competitorName = CompetitorName.Create(name);

            //Act
            competitor.UpdateCompetitorName(competitorName);

            //Assert
            Assert.Equal(name, competitor.CompetitorName.Name);
        }

        [Theory]
        [ClassData(typeof(UpdateCompetitorNameInvalidSeed))]
        public void UpdateCompetitorName_InvalidParameters(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var competitor = new CompetitorBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(MapCompetitorValidSeed))]
        public void MapCompetitor_ValidParameters(int oldBBCompetitorId, int oldMappingAgentId, int newBBCompetitorId, int newMappingAgentId)
        {
            //Arrange
            var competitor = new CompetitorBuilder()
                .WithBetContext(oldBBCompetitorId, oldMappingAgentId, DateTime.Now)
                .Build();

            //Act
            competitor.Map(newBBCompetitorId, newMappingAgentId);

            //Assert
            Assert.Equal(newBBCompetitorId, competitor.BetContext.BBCompetitorId);
            Assert.Equal(newMappingAgentId, competitor.BetContext.MappingAgentId);
        }

        [Theory]
        [ClassData(typeof(UnMapCompetitorValidSeed))]
        public void UnMapCompetitor_ValidParameters(int BBCompetitorId, int mappingAgentId)
        {
            //Arrange
            var competitor = new CompetitorBuilder()
                .WithBetContext(BBCompetitorId, mappingAgentId, DateTime.Now)
                .Build();

            //Act
            competitor.Unmap();

            //Assert
            Assert.Null(competitor.BetContext.BBCompetitorId);
            Assert.Null(competitor.BetContext.MappingAgentId);
        }

        [Theory]
        [ClassData(typeof(CompetitorIsMappedValidSeed))]
        public void IsMappedCompetitor_ValidParameters(int BBCompetitorId, int mappingAgentId)
        {
            //Arrange
            var competitor = new CompetitorBuilder()
                .WithBetContext(BBCompetitorId, mappingAgentId, DateTime.Now)
                .Build();

            //Act
            competitor.Map(BBCompetitorId, mappingAgentId);

            //Assert
            Assert.True(competitor.IsMapped());
        }
    }
}
