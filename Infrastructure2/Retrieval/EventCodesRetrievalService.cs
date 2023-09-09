namespace SportsBet.Infrastructure.Retrieval;

class EventCodesRetrievalService : IEventCodesRetrievalService
{
    private AchievementType[] achievementTypes = new AchievementType[0];
    private SpecialEventType[] specialEventTypes = new SpecialEventType[0];
    private StatType[] statTypes = new StatType[0];

    public Task<AchievementType[]> GetAchievementTypes()
    {
        //todo implementation
        return Task.FromResult(achievementTypes);
    }

    public Task<SpecialEventType[]> GetSpecialEventTypes()
    {
        //todo implementation
        return Task.FromResult(specialEventTypes);
    }

    public Task<StatType[]> GetStatTypes()
    {
        //todo implementation
        return Task.FromResult(statTypes);
    }
}

