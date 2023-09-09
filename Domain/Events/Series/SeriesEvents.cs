namespace SportsBet.Domain.Events.Series
{
    using Series = Aggregates.Series.Series;

    public class SeriesAddedEvent : BaseDomainEvent
    {
        public Series NewSeries { get; private set; }

        public SeriesAddedEvent(Series newSeries)
        {
            NewSeries = newSeries;
        }
    }

    public class SeriesUpdatedEvent : BaseDomainEvent
    {
        public Series UpdatedSeries { get; private set; }

        public SeriesUpdatedEvent(Series updatedSeries)
        {
            UpdatedSeries = updatedSeries;
        }
    }
    public class SeriesMatchAddedEvent : BaseDomainEvent
    {
        public Series NewSeries { get; private set; }

        public SeriesMatchAddedEvent(Series newSeries)
        {
            NewSeries = newSeries;
        }
    }

    public class SeriesMatchUpdatedEvent : BaseDomainEvent
    {
        public Series UpdatedSeries { get; private set; }

        public SeriesMatchUpdatedEvent(Series updatedSeries)
        {
            UpdatedSeries = updatedSeries;
        }
    }

    public class SeriesMatchAddedOrUpdatedEvent : BaseDomainEvent
    {
        public Series UpdatedSeries { get; private set; }

        public SeriesMatchAddedOrUpdatedEvent(Series updatedSeries)
        {
            UpdatedSeries = updatedSeries;
        }
    }
}
