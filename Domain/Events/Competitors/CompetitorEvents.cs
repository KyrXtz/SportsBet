namespace SportsBet.Domain.Events.Competitors
{
    public class CompetitorAddedEvent : BaseDomainEvent
    {
        public Competitor NewCompetitor { get; private set; }

        public CompetitorAddedEvent(Competitor newCompetitor)
        {
            NewCompetitor = newCompetitor;
        }
    }

    public class CompetitorUpdatedEvent : BaseDomainEvent
    {
        public Competitor UpdatedCompetitor { get; private set; }

        public CompetitorUpdatedEvent(Competitor updatedCompetitor)
        {
            UpdatedCompetitor = updatedCompetitor;
        }
    }

    public class CompetitorMappedEvent : BaseDomainEvent
    {
        public Competitor MappedCompetitor { get; private set; }

        public CompetitorMappedEvent(Competitor mappedCompetitor)
        {
            MappedCompetitor = mappedCompetitor;
        }
    }

    public class CompetitorUnmappedEvent : BaseDomainEvent
    {
        public Competitor UnmappedCompetitor { get; private set; }

        public CompetitorUnmappedEvent(Competitor unmappedCompetitor)
        {
            UnmappedCompetitor = unmappedCompetitor;
        }
    }
}
