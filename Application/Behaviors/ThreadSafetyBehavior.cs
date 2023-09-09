namespace SportsBet.Application.Behaviors
{
    class ThreadSafetyBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IThreadSafetyGuard<TRequest>? _guard;
        private readonly IDistributedLockProvider _synchronizationProvider;

        public ThreadSafetyBehavior(IDistributedLockProvider synchronizationProvider, IThreadSafetyGuard<TRequest>? guard = null)
        {
            _synchronizationProvider = synchronizationProvider;
            _guard = guard;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_guard == null)
                return await next();

            var @lock = _synchronizationProvider.CreateLock(_guard.GetLockName(request));
            await using var access = await @lock.AcquireAsync();
            return await next();
        }
    }
}