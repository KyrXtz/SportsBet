namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchScore : ValueObject
    {
        public int ScoreHome { get; private set; }
        public int ScoreAway { get; private set; }

        internal MatchScore(int scoreHome, int scoreAway)
        {
            ScoreHome = Guard.Against.InvalidInput(scoreHome, nameof(scoreHome), score => score >= 0);
            ScoreAway = Guard.Against.InvalidInput(scoreAway, nameof(scoreAway), score => score >= 0);
        }

        public static MatchScore Create(int scoreHome, int scoreAway)
        {
            return new MatchScore(scoreHome, scoreAway);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ScoreHome;
            yield return ScoreAway;
        }
    }
}
