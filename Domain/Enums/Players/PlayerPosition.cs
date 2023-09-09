namespace SportsBet.Domain.Enums.Players
{
    public sealed class PlayerPosition : SmartEnum<PlayerPosition>
    {
        public static readonly PlayerPosition Goalkeeper = new PlayerPosition(nameof(Goalkeeper), 0);
        public static readonly PlayerPosition Defender = new PlayerPosition(nameof(Defender), 1);
        public static readonly PlayerPosition Midfielder = new PlayerPosition(nameof(Midfielder), 2);
        public static readonly PlayerPosition Attacker = new PlayerPosition(nameof(Attacker), 3);
        public static readonly PlayerPosition UnknownS = new PlayerPosition(nameof(UnknownS), 4);
        public static readonly PlayerPosition CoachS = new PlayerPosition(nameof(CoachS), 5);
        public static readonly PlayerPosition SmallForward = new PlayerPosition(nameof(SmallForward), 6);
        public static readonly PlayerPosition PowerForward = new PlayerPosition(nameof(PowerForward), 7);
        public static readonly PlayerPosition PointGuard = new PlayerPosition(nameof(PointGuard), 8);
        public static readonly PlayerPosition Center = new PlayerPosition(nameof(Center), 9);
        public static readonly PlayerPosition ShootingGuard = new PlayerPosition(nameof(ShootingGuard), 10);
        public static readonly PlayerPosition Goaltender = new PlayerPosition(nameof(Goaltender), 11);
        public static readonly PlayerPosition Defenseman = new PlayerPosition(nameof(Defenseman), 12);
        public static readonly PlayerPosition CenterI = new PlayerPosition(nameof(CenterI), 13);
        public static readonly PlayerPosition Winger = new PlayerPosition(nameof(Winger), 14);
        public static readonly PlayerPosition CoachI = new PlayerPosition(nameof(CoachI), 15);
        public static readonly PlayerPosition Pitcher = new PlayerPosition(nameof(Pitcher), 16);
        public static readonly PlayerPosition RightFielder = new PlayerPosition(nameof(RightFielder), 17);
        public static readonly PlayerPosition ThirdBaseman = new PlayerPosition(nameof(ThirdBaseman), 18);
        public static readonly PlayerPosition Catcher = new PlayerPosition(nameof(Catcher), 19);
        public static readonly PlayerPosition LeftFielder = new PlayerPosition(nameof(LeftFielder), 20);
        public static readonly PlayerPosition ShortStop = new PlayerPosition(nameof(ShortStop), 21);
        public static readonly PlayerPosition FirstBaseman = new PlayerPosition(nameof(FirstBaseman), 22);
        public static readonly PlayerPosition SecondBaseman = new PlayerPosition(nameof(SecondBaseman), 23);
        public static readonly PlayerPosition CenterFielder = new PlayerPosition(nameof(CenterFielder), 24);
        public static readonly PlayerPosition DesignatedHitter = new PlayerPosition(nameof(DesignatedHitter), 25);
        public static readonly PlayerPosition UnknownB = new PlayerPosition(nameof(UnknownB), 26);
        public static readonly PlayerPosition Infielder = new PlayerPosition(nameof(Infielder), 27);
        public static readonly PlayerPosition Outfielder = new PlayerPosition(nameof(Outfielder), 28);
        public static readonly PlayerPosition Forward = new PlayerPosition(nameof(Forward), 32);
        public static readonly PlayerPosition UnknownI = new PlayerPosition(nameof(UnknownI), 33);




        private PlayerPosition() : base(default, default) { }

        public PlayerPosition(string name, int value) : base(name, value) { }
    }
}