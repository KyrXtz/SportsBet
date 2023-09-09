namespace SportsBet.Domain.Aggregates.ErroredCommandsLog;

public class ErroredCommandLog : BaseEntity<long>, IAggregateRoot
{
    public ErroredCommandLogIdentity ExceptionIdentity { get; private set; }
    public ErroredCommandLogData ExceptionData { get; private set; }

    private ErroredCommandLog() { }

    private ErroredCommandLog(ErroredCommandLogIdentity erroredIdentity, ErroredCommandLogData erroredData)
    {
        Id = UniqueIdGenerator.CreateId();
        ExceptionIdentity = erroredIdentity;
        ExceptionData = erroredData;
    }

    public static ErroredCommandLog Create(string command,
        string data,
        string message)
    {
        var erroredIdentity = ErroredCommandLogIdentity.Create(commandName: command);
        var erroredData = ErroredCommandLogData.Create(data: data, message: message);

        return new ErroredCommandLog(erroredIdentity: erroredIdentity,
            erroredData: erroredData);
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}