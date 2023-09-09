namespace SportsBet.Domain.ValueObjects.Series
{
    public class SeriesScore : ValueObject
    {
        public int? Score { get; private set; }
        public int? Standing { get; private set; }

        private SeriesScore() { }

        internal SeriesScore(int? score, int? standing)
        {
            Score = Guard.Against.InvalidInput(score, nameof(score), score => score >= 0); 
            Standing = Guard.Against.InvalidInput(standing, nameof(standing), standing => standing >= 0);
        }

        public static SeriesScore Create(int? score, int? standing)
        {
            return new SeriesScore(score, standing);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Score;
            yield return Standing;
        }
    }
}
