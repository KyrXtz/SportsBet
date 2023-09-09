namespace SportsBet.Domain.Aggregates.Matches
{
    public class MatchStat : BaseEntity<long>
    {
        public MatchStatValue Stat { get; private set; }
        public int CompetitorId { get; private set; }
        public int? PlayerId { get; private set; }

        private MatchStat() { }

        internal MatchStat(MatchStatValue stat, int teamId, int? playerId)
        {
            Id = UniqueIdGenerator.CreateId();
            Stat = stat;
            CompetitorId = teamId;
            PlayerId = playerId;
        }

        public static MatchStat Create(int eventId,
            string value,
            int competitorId,
            int? playerId)
        {
            var stat = MatchStatValue.Create(eventId: eventId, value: value);

            return new MatchStat(stat: stat,
                teamId: competitorId,
                playerId: playerId);
        }

        internal void Update(int eventId, string value, int? playerId)
        {
            var stat = MatchStatValue.Create(eventId: eventId, value: value);

            Stat = stat;
            PlayerId = playerId;
        }

        internal void UpdateStatValue(MatchStatValue stat)
        {
            Stat = stat;
        }

        internal void UpdatePlayer(int? playerId)
        {
            PlayerId = playerId;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
