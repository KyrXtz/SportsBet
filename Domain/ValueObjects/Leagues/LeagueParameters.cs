namespace SportsBet.Domain.ValueObjects.Leagues
{
    public class LeagueParameters : ValueObject
    {
        public string? RegularPlaytime { get; private set; }
        public string? OverPlaytime { get; private set; } 
        public bool? HasPenaltyShootout { get; private set; }
        public bool? HasPlayerData { get; private set; }
        
        internal LeagueParameters(string? regularPlaytime, string? overPlaytime, bool? hasPenaltyShootout, bool? hasPlayerData)
        {
            RegularPlaytime = regularPlaytime;
            OverPlaytime = overPlaytime;
            HasPenaltyShootout = hasPenaltyShootout;
            HasPlayerData = hasPlayerData;
        }

        public static LeagueParameters Create(string? regularPlaytime,
            string? overPlaytime,
            bool? hasPenaltyShootout,
            bool? hasPlayerData)
        {
            return new LeagueParameters(regularPlaytime, overPlaytime, hasPenaltyShootout, hasPlayerData);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RegularPlaytime;
            yield return OverPlaytime;
            yield return HasPenaltyShootout;
            yield return HasPlayerData;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
