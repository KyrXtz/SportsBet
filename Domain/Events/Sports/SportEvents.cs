namespace SportsBet.Domain.Events.Sports
{
    public class SportAddedEvent : BaseDomainEvent
    {
        public Sport NewSport { get; private set; }

        public SportAddedEvent(Sport newSport)
        {
            NewSport = newSport;
        }
    }

    public class SportUpdatedEvent : BaseDomainEvent
    {
        public Sport UpdatedSport { get; private set; }

        public SportUpdatedEvent(Sport updatedSport)
        {
            UpdatedSport = updatedSport;
        }
    }

    public class SportMappedEvent : BaseDomainEvent
    {
        public Sport MappedSport { get; private set; }

        public SportMappedEvent(Sport mappedSport)
        {
            MappedSport = mappedSport;
        }
    }

    public class SportUnmappedEvent : BaseDomainEvent
    {
        public Sport UnmappedSport { get; private set; }

        public SportUnmappedEvent(Sport unmappedSport)
        {
            UnmappedSport = unmappedSport;
        }
    }
}
