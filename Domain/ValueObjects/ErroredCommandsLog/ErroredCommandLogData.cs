namespace SportsBet.Domain.ValueObjects.ErroredCommandsLog;

public class ErroredCommandLogData : ValueObject
{
    public string Data { get; private set; }
    public string Message { get; private set; }

    private ErroredCommandLogData(string data, string message)
    {
        Data = Guard.Against.NullOrWhiteSpace(data, nameof(data));
        Message = Guard.Against.NullOrWhiteSpace(message, nameof(message));
    }

    public static ErroredCommandLogData Create(string data, string message)
    {
        return new ErroredCommandLogData(data, message);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Data;
        yield return Message;
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }
}