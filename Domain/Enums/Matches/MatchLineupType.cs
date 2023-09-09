namespace SportsBet.Domain.Enums.Matches
{
    public sealed class MatchLineupType : SmartEnum<MatchLineupType>
    {
        public static readonly MatchLineupType None = new MatchLineupType(nameof(None), 0);
        public static readonly MatchLineupType Starting11 = new MatchLineupType(nameof(Starting11), 1);
        public static readonly MatchLineupType Suspended = new MatchLineupType(nameof(Suspended), 2);
        public static readonly MatchLineupType Injured = new MatchLineupType(nameof(Injured), 3);
        public static readonly MatchLineupType Bench = new MatchLineupType(nameof(Bench), 4);
        public static readonly MatchLineupType Reserve = new MatchLineupType(nameof(Reserve), 5);
        public static readonly MatchLineupType StartingPlayer = new MatchLineupType(nameof(StartingPlayer), 6);


        private MatchLineupType() : base(default, default) { }

        public MatchLineupType(string name, int value) : base(name, value) { }
    }
}