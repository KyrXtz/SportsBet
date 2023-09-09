using IdGen;

namespace SportsBet.Domain.ValueObjects.Series
{
    public class SeriesTeam : ValueObject
    {
        public int TeamId { get; private set; }
        public SeriesScore Score { get; private set; }
        
        private SeriesTeam() { }

        private SeriesTeam(int teamId, SeriesScore score)
        {
            TeamId = Guard.Against.InvalidInput(teamId, nameof(teamId), teamId => teamId > 0);
            Score = score;
        }

        public static SeriesTeam Create(int teamId, SeriesScore score)
        {
            return new SeriesTeam(teamId, score);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TeamId;
            yield return Score;
        }
    }
}
