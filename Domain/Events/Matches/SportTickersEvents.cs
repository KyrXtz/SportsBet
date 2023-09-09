namespace SportsBet.Domain.Events.Matches
{
    public class MatchAddedEvent : BaseDomainEvent
    {
        public Match NewMatch { get; private set; }

        public MatchAddedEvent(Match newMatch)
        {
            NewMatch = newMatch;
        }
    }

    public class MatchUpdatedEvent : BaseDomainEvent
    {
        public Match UpdatedMatch { get; private set; }

        public MatchUpdatedEvent(Match updatedMatch)
        {
            UpdatedMatch = updatedMatch;
        }
    }

    public class MatchMappedEvent : BaseDomainEvent
    {
        public Match MappedMatch { get; private set; }

        public MatchMappedEvent(Match mappedMatch)
        {
            MappedMatch = mappedMatch;
        }
    }

    public class MatchUnmappedEvent : BaseDomainEvent
    {
        public Match UnmappedMatch { get; private set; }

        public MatchUnmappedEvent(Match unmappedMatch)
        {
            UnmappedMatch = unmappedMatch;
        }
    }
    public class MatchDetailsAddedEvent : BaseDomainEvent
    {
        public Match UpdatedMatch { get; private set; }

        public MatchDetailsAddedEvent(Match updatedMatch)
        {
            UpdatedMatch = updatedMatch;
        }
    }

    public class MatchCompetitorsAddedOrUpdatedEvent : BaseDomainEvent
    {
        public Match Match { get; private set; }

        public MatchCompetitorsAddedOrUpdatedEvent(Match match)
        {
            Match = match;
        }
    }

    public class MatchDateChangedEvent : BaseDomainEvent
    {
        public Match Match { get; private set; }

        public MatchDateChangedEvent(Match match)
        {
            Match = match;
        }
    }

    public class MatchStatusChangedEvent : BaseDomainEvent
    {
        public Match Match { get; private set; }

        public MatchStatusChangedEvent(Match match)
        {
            Match = match;
        }
    }

    public class MatchStatsAddedEvent : BaseDomainEvent
    {
        public Match Match { get; private set; }

        public MatchStatsAddedEvent(Match updatedMatch)
        {
            Match = updatedMatch;
        }
    }
    public class MatchStatsUpdatedEvent : BaseDomainEvent
    {
        public Match Match { get; private set; }

        public MatchStatsUpdatedEvent(Match updatedMatch)
        {
            Match = updatedMatch;
        }
    }

    //public class MatchStatJobAddedEvent : BaseDomainEvent
    //{
    //    public MatchStatJob NewMatchStatJob { get; private set; }

    //    public MatchStatJobAddedEvent(MatchStatJob newMatchStatJob)
    //    {
    //        NewMatchStatJob = newMatchStatJob;
    //    }
    //}

    //public class MatchStatJobUpdatedEvent : BaseDomainEvent
    //{
    //    public MatchStatJob UpdatedMatchStatJob { get; private set; }

    //    public MatchStatJobUpdatedEvent(MatchStatJob updatedMatchStatJob)
    //    {
    //        UpdatedMatchStatJob = updatedMatchStatJob;
    //    }
    //}

    public class MatchLineupAddedOrUpdatedEvent : BaseDomainEvent
    {
        public Match UpdatedMatch { get; private set; }

        public MatchLineupAddedOrUpdatedEvent(Match updatedMatch)
        {
            UpdatedMatch = updatedMatch;
        }
    }
    public class MatchLineupTypeUpdatedEvent : BaseDomainEvent
    {
        public Match UpdatedMatch { get; private set; }

        public MatchLineupTypeUpdatedEvent(Match updatedMatch)
        {
            UpdatedMatch = updatedMatch;
        }
    }
    public class MatchStatAddedOrUpdatedEvent : BaseDomainEvent
    {
        public Match UpdatedMatch { get; private set; }

        public MatchStatAddedOrUpdatedEvent(Match updatedMatch)
        {
            UpdatedMatch = updatedMatch;
        }
    }

    public class MatchScoreUpdatedEvent : BaseDomainEvent
    {
        public Match UpdatedMatch { get; private set; }

        public MatchScoreUpdatedEvent(Match updatedMatch)
        {
            UpdatedMatch = updatedMatch;
        }
    }
    public class MatchEventAddedOrUpdatedEvent : BaseDomainEvent
    {
        public Match UpdatedMatch { get; private set; }

        public MatchEventAddedOrUpdatedEvent(Match updatedMatch)
        {
            UpdatedMatch = updatedMatch;
        }
    }
}
