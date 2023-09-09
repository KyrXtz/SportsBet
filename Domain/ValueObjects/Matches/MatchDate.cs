namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchDate : ValueObject
    {
        public DateTime GameStart { get; private set; }

        internal MatchDate(DateTime gameStart)
        {
            GameStart = Guard.Against.Null(gameStart, nameof(gameStart));
        }

        public static MatchDate Create(DateTime gameStart)
        {
            return new MatchDate(gameStart);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return GameStart;
        }   
    }
}
