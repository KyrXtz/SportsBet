namespace SportsBet.Domain.Enums.Matches
{
    public sealed class MatchState : SmartEnum<MatchState>
    {
        public static readonly MatchState Open = new MatchState(nameof(Open), 0);
        public static readonly MatchState Finished = new MatchState(nameof(Finished), 1);
        public static readonly MatchState Cancelled = new MatchState(nameof(Cancelled), 2);
        public static readonly MatchState Running = new MatchState(nameof(Running), 3);
        public static readonly MatchState Suspended = new MatchState(nameof(Suspended), 4);


        private MatchState() : base(default, default) { }

        public MatchState(string name, int value) : base(name, value) { }


    }
}
