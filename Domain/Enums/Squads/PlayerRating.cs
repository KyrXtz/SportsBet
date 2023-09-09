namespace SportsBet.Domain.Enums.Squads
{
    public sealed class PlayerRating : SmartEnum<PlayerRating>
    {
        public static readonly PlayerRating Unrated = new PlayerRating(nameof(Unrated), 0);
        public static readonly PlayerRating Premium = new PlayerRating(nameof(Premium), 1);
        public static readonly PlayerRating Intrinsic = new PlayerRating(nameof(Intrinsic), 2);
        public static readonly PlayerRating Established = new PlayerRating(nameof(Established), 3);
        public static readonly PlayerRating Fringe = new PlayerRating(nameof(Fringe), 4);
        public static readonly PlayerRating Infrequent = new PlayerRating(nameof(Infrequent), 5);

        private PlayerRating() : base(default, default) { }

        public PlayerRating(string name, int value) : base(name, value) { }
    }
}