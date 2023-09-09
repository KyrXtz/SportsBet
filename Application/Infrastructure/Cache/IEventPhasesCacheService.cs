namespace SportsBet.Application.Infrastructure.Cache
{
    public interface IEventPhasesCacheService
    {
        int GetIdBySysName(string sysName);
        string GetSysNameById(int id);
        Dictionary<int, string> GetAll();
    }
}