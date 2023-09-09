namespace SportsBet.Application.Commands.MatchesEvents;

public class UpdateMatchsEventsCommand : CommandBase, IRequest<Result<List<long>>>, IErroredCommand
{
    public IEnumerable<MatchEventUpdatedItem> MatchSpecialEvents { get; private set; }
    private UpdateMatchsEventsCommand() { }
    public UpdateMatchsEventsCommand(IEnumerable<MatchEventUpdatedItem> matchSpecialEvents)
    {
        MatchSpecialEvents = matchSpecialEvents;
    }
}

public class MatchEventUpdatedItem : CommandItemBase
{
    public int MatchId { get; set; }
    public int EventNumber { get; set; }
    public Dictionary<string, string> SpecialEventValues { get; set; }
    public int EventReasonId { get; set; }
    public string EventReasonValue { get; set; }
    public int[] RelatedMatchEventNumbers { get; set; }
    public int[] ClearedMatchEventNumbers { get; set; }
}
