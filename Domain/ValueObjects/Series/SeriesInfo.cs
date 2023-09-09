namespace SportsBet.Domain.ValueObjects.Series;
public class SeriesInfo : ValueObject
{
    public int NumberOfMatches { get; private set; }

    internal SeriesInfo(int numberOfMatches)
    {
        NumberOfMatches = Guard.Against.InvalidInput(numberOfMatches, nameof(numberOfMatches), numberOfMatches => numberOfMatches > 0);
    }

    public static SeriesInfo Create(int numberOfMatches)
    {
        return new SeriesInfo(numberOfMatches);
    }

    protected override void Validate()
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return NumberOfMatches;
    }
}