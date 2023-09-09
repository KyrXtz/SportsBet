using Unit = MediatR.Unit;

namespace SportsBet.Application.Commands.Jobs
{
    public class IntegrationEventOutboxJobCommand : CommandBase, IRequest<Result<Unit>>
    {

    }
}

