namespace SportsBet.Infrastructure.Bus;

class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task RaiseEvent<T>(T @event, CancellationToken cancellationToken) where T : INotification
    {
        return _mediator.Publish(@event, cancellationToken);
    }

    public async Task<Result<U>> SendCommand<U>(CommandBase command, CancellationToken cancellationToken)
    {
        var task = await _mediator.Send(command, cancellationToken);

        return (Result<U>)task;
    }
    public async Task<Result<U>> SendQuery<U>(QueryBase query, CancellationToken cancellationToken)
    {
        var task = await _mediator.Send(query, cancellationToken);

        return (Result<U>)task;
    }
}