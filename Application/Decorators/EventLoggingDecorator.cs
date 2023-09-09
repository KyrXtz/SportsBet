namespace SportsBet.Application.Decorators
{
    class EventLoggingDecorator<TNotification> : INotificationHandler<TNotification>
        where TNotification : INotification
    {
        private readonly INotificationHandler<TNotification> _decorated;
        private readonly ILogger<TNotification> _logger;

        public EventLoggingDecorator(INotificationHandler<TNotification> decorated,
            ILogger<TNotification> logger)
        {
            _decorated = decorated;
            _logger = logger;
        }

        public async Task Handle(TNotification notification, CancellationToken cancellationToken)
        {         
            var req = JsonConvert.SerializeObject(notification, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            _logger.LogInformation($"Handling event {typeof(TNotification).Name} with data : {req}");

            await _decorated.Handle(notification, cancellationToken);
        }
    }
}