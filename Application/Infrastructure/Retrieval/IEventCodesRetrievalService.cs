namespace SportsBet.Application.Infrastructure.Retrieval;
public interface IEventCodesRetrievalService
{
    Task<SpecialEventType[]> GetSpecialEventTypes();
    Task<StatType[]> GetStatTypes();
    Task<AchievementType[]> GetAchievementTypes();
}

