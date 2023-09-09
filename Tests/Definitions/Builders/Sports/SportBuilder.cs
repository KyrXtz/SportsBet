namespace TestDefinitions.Builders
{
    public class SportBuilder
    {
        private int id = 1;
        private string name = "SportName";
        private int bBCompetitionContextId = 1;
        private int mappingAgentId = 1;

        public Sport Build()
        {
            var sport = Sport.Create(id, name);
            sport.Map(bBCompetitionContextId, mappingAgentId);
            return sport;
        }
        public SportBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }
        public SportBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public SportBuilder WithBetContext(int bBCompetitionContextId, int mappingAgentId)
        {
            this.bBCompetitionContextId = bBCompetitionContextId;
            this.mappingAgentId = mappingAgentId;
            return this;
        }

        public static implicit operator Sport(SportBuilder instance)
        {
            return instance.Build();
        }
    }
}
