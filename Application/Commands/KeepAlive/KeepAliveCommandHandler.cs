namespace SportsBet.Application.Commands.KeepAlive;

class KeepAliveCommandHandler : IRequestHandler<KeepAliveCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(KeepAliveCommand request, CancellationToken cancellationToken)
    {
        return Result<Unit>.Success();
    }
}