namespace SportsBet.Domain.ValueObjects.ErroredCommandsLog;

public class ErroredCommandLogIdentity : ValueObject
{
    public string CommandName { get; private set; }

    private ErroredCommandLogIdentity(string commandName)
    {
        CommandName = Guard.Against.NullOrWhiteSpace(commandName, nameof(commandName));
    }

    public static ErroredCommandLogIdentity Create(string commandName)
    {
        return new ErroredCommandLogIdentity(commandName);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CommandName;
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}