namespace SportsBet.Application.Infrastructure.Http
{
    public interface IHttpRepository
    {
        Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default);
    }
}
