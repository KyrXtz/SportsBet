namespace SportsBet.Domain.Events.MatchesEvents;
public class MatchEventAddedEvent : BaseDomainEvent
{
    public MatchEvent NewMatchEvent { get; private set; }

    public MatchEventAddedEvent(MatchEvent newMatchEvent)
    {
        NewMatchEvent = newMatchEvent;
    }
}

public class MatchEventUpdatedEvent : BaseDomainEvent
{
    public MatchEvent UpdatedMatchEvent { get; private set; }

    public MatchEventUpdatedEvent(MatchEvent updatedMatchEvent)
    {
        UpdatedMatchEvent = updatedMatchEvent;
    }
}