namespace SportsBet.Application.Infrastructure.Concurrency
{
    public interface IThreadSafetyGuard<TRequest>
    {
        string GetLockName(TRequest request);
    }
}