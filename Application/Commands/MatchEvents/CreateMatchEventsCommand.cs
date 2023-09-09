namespace SportsBet.Application.Commands.MatchesEvents;
public class CreateMatchsEventsCommand : CommandBase, IRequest<Result<List<long>>>, IErroredCommand
{
    public IEnumerable<MatchEventItem> MatchEvents { get; private set; }
    private CreateMatchsEventsCommand() { }
    public CreateMatchsEventsCommand(IEnumerable<MatchEventItem> matchEvents)
    {
        MatchEvents = matchEvents;
    }
}

public class MatchEventItem : CommandItemBase
{
    public int MatchId { get; set; }
    public int EventCodeId { get; set; }
    public int EventNumber { get; set; }
    public string EventCode { get; set; }
    public int MatchStateId { get; set; }
    public int Minute { get; set; }
    public long Timestamp { get; set; }
    public bool? ClockRunning { get; set; }
    public DateTime Date { get; set; }
}