namespace TestDefinitions.Builders.Competitors;

public class CompetitorBuilder
{
    private int id = 1;
    private int sportId = 1;
    private int countryId = 1;
    private bool isIndividual = true;
    private int mappingAgentId = 1;
    private int bBCompetitorId = 1;
    private DateTime mappedAt = DateTime.Now;
    private string name = "name";
    private string code = "code";

    public Competitor Build()
    {
        var competitor = Competitor.Create(id, name, isIndividual, sportId, countryId);
        competitor.Map(bBCompetitorId, mappingAgentId);

        return competitor;
    }

    public CompetitorBuilder WithId(int id)
    {
        this.id = id;
        return this;
    }
    public CompetitorBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }
    public CompetitorBuilder WithCode(string code)
    {
        this.code = code;
        return this;
    }

    public CompetitorBuilder WithCountry(int countryId)
    {
        this.countryId = countryId;
        return this;
    }

    public CompetitorBuilder WithSport(int sportId)
    {
        this.sportId = sportId;
        return this;
    }

    public CompetitorBuilder WithBetContext(int bBCompetitorId, int mappingAgentId, DateTime mappedAt)
    {
        this.bBCompetitorId = bBCompetitorId;
        this.mappingAgentId = mappingAgentId;
        this.mappedAt = mappedAt;
        return this;
    }

    public static implicit operator Competitor(CompetitorBuilder instance)
    {
        return instance.Build();
    }
}

