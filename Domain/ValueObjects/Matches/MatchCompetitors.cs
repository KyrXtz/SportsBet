namespace SportsBet.Domain.ValueObjects.Matches
{
    public class MatchCompetitors : ValueObject
    {
        public int HomeCompetitorId { get; private set; }
        public int AwayCompetitorId { get; private set; }

        internal MatchCompetitors(int homeCompetitorId, int awayCompetitorId)
        {
            HomeCompetitorId = Guard.Against.Null(homeCompetitorId, nameof(homeCompetitorId));
            AwayCompetitorId = Guard.Against.Null(awayCompetitorId, nameof(awayCompetitorId));
        }

        public static MatchCompetitors Create(int homeCompetitorId, int awayCompetitorId)
        {
            return new MatchCompetitors(homeCompetitorId, awayCompetitorId);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return HomeCompetitorId;
            yield return AwayCompetitorId;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
