namespace SportsBet.Application.Decorators
{
    class IntegrationEventOutboxItemDecorator<TNotification> : INotificationHandler<TNotification>
        where TNotification : BaseIntegrationEvent
    {
        private readonly INotificationHandler<TNotification> _decorated;
        private readonly IRepository<IntegrationEventOutboxItem> _integrationEventOutboxRepository;
        private readonly ILogger<TNotification> _logger;

        public IntegrationEventOutboxItemDecorator(INotificationHandler<TNotification> decorated,
            IRepository<IntegrationEventOutboxItem> integrationEventOutboxRepository,
            ILogger<TNotification> logger)
        {
            _decorated = decorated;
            _integrationEventOutboxRepository = integrationEventOutboxRepository;
            _logger = logger;
        }

        public async Task Handle(TNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();             
        }
    }
}

