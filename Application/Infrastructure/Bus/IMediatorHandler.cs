namespace SportsBet.Application.Infrastructure.Bus
{
    public interface IMediatorHandler
    {
        /// <summary>
        /// Only BaseDomainEvent allowed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RaiseEvent<T>(T @event, CancellationToken cancellationToken) where T : INotification;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Result<U>> SendCommand<U>(CommandBase command, CancellationToken cancellationToken);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        Task<Result<U>> SendQuery<U>(QueryBase query, CancellationToken cancellationToken);

    }
}
