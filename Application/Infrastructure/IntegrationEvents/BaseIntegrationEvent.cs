namespace SportsBet.Application.Infrastructure.IntegrationEvents
{
    public abstract class BaseIntegrationEvent : INotification
    {
        public Guid EventId { get; protected set; }
        public DateTime DateOccurred { get; protected set; }

        protected BaseIntegrationEvent() { }

        public BaseIntegrationEvent(Guid eventId, DateTime dateOccurred)
        {
            EventId = eventId;
            DateOccurred = dateOccurred;
        }
    }
}