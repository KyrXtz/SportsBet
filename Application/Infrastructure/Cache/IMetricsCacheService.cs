namespace SportsBet.Application.Infrastructure.Cache
{
    public interface IMetricsCacheService
    {
        int GetIdBySysName(string sysName);
    }
}