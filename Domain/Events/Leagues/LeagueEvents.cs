namespace SportsBet.Domain.Events.Leagues
{
    public class LeagueAddedEvent : BaseDomainEvent
    {
        public League NewLeague { get; private set; }

        public LeagueAddedEvent(League newLeague)
        {
            NewLeague = newLeague;
        }
    }

    public class LeagueUpdatedEvent : BaseDomainEvent
    {
        public League UpdatedLeague { get; private set; }

        public LeagueUpdatedEvent(League updatedLeague)
        {
            UpdatedLeague = updatedLeague;
        }
    }
    public class LeagueGameModeDetailsAddedEvent : BaseDomainEvent
    {
        public League UpdatedLeague { get; private set; }

        public LeagueGameModeDetailsAddedEvent(League updatedLeague)
        {
            UpdatedLeague = updatedLeague;
        }
    }

    public class LeagueMappedEvent : BaseDomainEvent
    {
        public League MappedLeague { get; private set; }

        public LeagueMappedEvent(League mappedLeague)
        {
            MappedLeague = mappedLeague;
        }
    }

    public class LeagueUnmappedEvent : BaseDomainEvent
    {
        public League UnmappedLeague { get; private set; }

        public LeagueUnmappedEvent(League unmappedLeague)
        {
            UnmappedLeague = unmappedLeague;
        }
    }
}
