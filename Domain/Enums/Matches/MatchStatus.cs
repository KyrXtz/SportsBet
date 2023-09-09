namespace SportsBet.Domain.Enums.Matches
{
    public sealed class MatchStatus : SmartEnum<MatchStatus>
    {
        public static readonly MatchStatus Open = new MatchStatus(nameof(Open), 0);
        public static readonly MatchStatus Finished = new MatchStatus(nameof(Finished), 1);
        public static readonly MatchStatus Cancelled = new MatchStatus(nameof(Cancelled), 2);
        public static readonly MatchStatus Running = new MatchStatus(nameof(Running), 3);
        public static readonly MatchStatus Suspended = new MatchStatus(nameof(Suspended), 4);


        private MatchStatus() : base(default, default) { }

        public MatchStatus(string name, int value) : base(name, value) { }
    }
}
