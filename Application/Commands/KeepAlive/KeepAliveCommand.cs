namespace SportsBet.Application.Commands.KeepAlive;
public class KeepAliveCommand : Webhook
{
    public KeepAlivePayload Payload { get; private set; }
    
    private KeepAliveCommand() { }
    public KeepAliveCommand(KeepAlivePayload payload)
    {
        Payload = payload;
    }   
}

#region Payload Records
public record KeepAlivePayload(KeepAlive KeepAlive)
{
    public KeepAlivePayload() : this(new KeepAlive(DateTime.UtcNow, default))
    {
    }
}

public record KeepAlive(DateTime DateGenerated, int PusherId);
#endregion