namespace SportsBet.Application.Infrastructure.BetContext
{
    public interface IMatchAchievementsService
    {
        Task<int> CreateIncident(int betContextId, IncidentPayload incident);
        Task UpdateIncident(int betContextId, UpdateIncidentPayload incident);
        Task BetLock(int betContextId, string marketGroupSysname);
    }
}