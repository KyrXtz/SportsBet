namespace SportsBet.Application.Infrastructure.Cache
{
    public interface ICacheService
    {
        Task<TObject> GetOrSetValueAsync<TObject>(string key, Func<Task<TObject>> method,Func<DistributedCacheEntryOptions> options) where TObject : class;
        Task<TObject> GetOrSetValueAsync<TObject>(string key,Func<Task<TObject>> method, DistributedCacheEntryOptions options) where TObject : class;
        Task<TObject> GetValueAsync<TObject>(string key) where TObject : class;

        Task<TObject> GetOrSetValueAsync<TObject>(string key, Func<Task<TObject>> method, 
            Func<DistributedCacheEntryOptions> options, 
            CancellationToken cancellationToken) where TObject : class;
        Task<TObject> GetOrSetValueAsync<TObject>(string key, Func<Task<TObject>> method, 
            DistributedCacheEntryOptions options,
             CancellationToken cancellationToken) where TObject : class;
        Task<TObject> GetValueAsync<TObject>(string key, CancellationToken cancellationToken) where TObject : class;
    }
}
