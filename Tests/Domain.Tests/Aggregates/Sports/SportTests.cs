namespace Domain.Tests.Aggregates.Sports
{
    public class SportTests
    {
        [Theory]
        [ClassData(typeof(SportValidSeed))]
        public void Create_ValidParameters(string name)
        {
            var sport = new SportBuilder()
                .WithName(name)
                .Build();

            Assert.NotNull(sport);
            Assert.Equal(name, sport.Name.Name);
        }

        [Theory]
        [ClassData(typeof(SportInvalidSeed))]
        public void Create_InvalidParameters(int id, string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var sport = new SportBuilder()
                    .WithId(id)
                    .WithName(name)
                    .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateSportValidSeed))]
        public void UpdateSport_ValidParameters(string name)
        {
            //Arrange
            var sport = new SportBuilder()
                .Build();

            //Act
            sport.Update(name);

            //Assert
            Assert.Equal(name, sport.Name.Name);
        }

        [Theory]
        [ClassData(typeof(UpdateSportInvalidSeed))]
        public void UpdateSport_InvalidParameters(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var sport = new SportBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(UpdateSportNameValidSeed))]
        public void UpdateSportName_ValidParameters(string name)
        {
            //Arrange
            var sport = new SportBuilder()
                .Build();

            var sportName = SportName.Create(name);

            //Act
            sport.UpdateSportName(sportName);

            //Assert
            Assert.Equal(name, sport.Name.Name);
        }

        [Theory]
        [ClassData(typeof(UpdateSportNameInvalidSeed))]
        public void UpdateSportName_InvalidParameters(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                var sport = new SportBuilder()
                .WithName(name)
                .Build();
            });
        }

        [Theory]
        [ClassData(typeof(MapSportValidSeed))]
        public void MapSport_ValidParameters(int oldBBCompetitionContextId, int oldMappingAgentId, int newBBCompetitionContextId, int newMappingAgentId)
        {
            //Arrange
            var sport = new SportBuilder()
                .WithBetContext(oldBBCompetitionContextId, oldMappingAgentId)
                .Build();

            //Act
            sport.Map(newBBCompetitionContextId, newMappingAgentId);

            //Assert
            Assert.Equal(newBBCompetitionContextId, sport.BetContext.BBCompetitionContextId);
            Assert.Equal(newMappingAgentId, sport.BetContext.MappingAgentId);
        }

        [Theory]
        [ClassData(typeof(UnMapSportValidSeed))]
        public void UnMapSport_ValidParameters(int bBCompetitionContextId, int mappingAgentId)
        {
            //Arrange
            var sport = new SportBuilder()
                .WithBetContext(bBCompetitionContextId, mappingAgentId)
                .Build();

            //Act
            sport.Unmap();

            //Assert
            Assert.Null(sport.BetContext.BBCompetitionContextId);
            Assert.Null(sport.BetContext.MappingAgentId);
        }

        //[Theory]
        //[ClassData(typeof(SportIsMappedValidSeed))]
        //public void IsMapped_ValidParameters(int id, string name)
        //{
        //    var sport = Sport.Create(id: id, name: name);

        //    var isMapped = sport.IsMapped();

        //    Assert.NotNull(isMapped);
        //    Assert.Equal(name, sport.Name.Name);
        //}

    }
}
