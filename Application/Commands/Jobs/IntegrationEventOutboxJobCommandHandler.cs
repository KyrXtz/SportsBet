using Unit = MediatR.Unit;

namespace SportsBet.Application.Commands.Jobs
{
    class IntegrationEventOutboxJobCommandHandler : IRequestHandler<IntegrationEventOutboxJobCommand, Result<Unit>>
    {
        private readonly IRepository<IntegrationEventOutboxItem> _integrationEventOutboxRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public IntegrationEventOutboxJobCommandHandler(IRepository<IntegrationEventOutboxItem> integrationEventOutboxRepository,
            IMediatorHandler mediatorHandler)
        {
            _integrationEventOutboxRepository = integrationEventOutboxRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Result<Unit>> Handle(IntegrationEventOutboxJobCommand request, CancellationToken cancellationToken)
        {
            var pendingEventOutboxItems = await _integrationEventOutboxRepository.ListAsync(new GetNotCompletedIntegrationEventOutboxItemsSpecification());

            foreach (var eventOutboxItem in pendingEventOutboxItems)
            {
                var integrationEvent = JsonConvert.DeserializeObject(eventOutboxItem.EventData.Data,
                    Type.GetType(eventOutboxItem.EventIdentity.EventName)) as BaseIntegrationEvent;


                if (integrationEvent != null)
                {
                    await _mediatorHandler.RaiseEvent(integrationEvent, default);
                }
            }

            return Result<Unit>.Success();
        }
    }
}

