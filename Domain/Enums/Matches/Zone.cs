namespace SportsBet.Domain.Enums.Matches
{
    public sealed class Zone : SmartEnum<Zone>
    {
        public static readonly Zone FK1 = new Zone(nameof(FK1), 0);
        public static readonly Zone FK2 = new Zone(nameof(FK2), 1);
        public static readonly Zone FK3L = new Zone(nameof(FK3L), 2);
        public static readonly Zone FK3R = new Zone(nameof(FK3R), 3);
        public static readonly Zone FK4 = new Zone(nameof(FK4), 4);
        public static readonly Zone FK5 = new Zone(nameof(FK5), 5);
        public static readonly Zone CR_L = new Zone(nameof(CR_L), 6);
        public static readonly Zone CR_R = new Zone(nameof(CR_R), 7);
        public static readonly Zone TL = new Zone(nameof(TL), 8);
        public static readonly Zone TC = new Zone(nameof(TC), 9);
        public static readonly Zone TR = new Zone(nameof(TR), 10);
        public static readonly Zone BL = new Zone(nameof(BL), 11);
        public static readonly Zone BC = new Zone(nameof(BC), 12);
        public static readonly Zone BR = new Zone(nameof(BR), 13);
        public static readonly Zone IH_Z1 = new Zone(nameof(IH_Z1), 14);
        public static readonly Zone IH_Z2L = new Zone(nameof(IH_Z2L), 15);
        public static readonly Zone IH_Z2R = new Zone(nameof(IH_Z2R), 16);
        public static readonly Zone IH_Z3L = new Zone(nameof(IH_Z3L), 17);
        public static readonly Zone IH_Z3R = new Zone(nameof(IH_Z3R), 18);
        public static readonly Zone IH_Z4 = new Zone(nameof(IH_Z4), 19);
        public static readonly Zone T_Z1 = new Zone(nameof(T_Z1), 20);
        public static readonly Zone T_Z2L = new Zone(nameof(T_Z2L), 21);
        public static readonly Zone T_Z2R = new Zone(nameof(T_Z2R), 22);
        public static readonly Zone T_Z3L = new Zone(nameof(T_Z3L), 23);
        public static readonly Zone T_Z3R = new Zone(nameof(T_Z3R), 24);
        public static readonly Zone T_Z4 = new Zone(nameof(T_Z4), 25);
        public static readonly Zone T_Z5L = new Zone(nameof(T_Z5L), 26);
        public static readonly Zone T_Z5R = new Zone(nameof(T_Z5R), 27);
        public static readonly Zone T_Z5LAL = new Zone(nameof(T_Z5LAL), 28);
        public static readonly Zone T_Z5LAM = new Zone(nameof(T_Z5LAM), 29);
        public static readonly Zone T_Z5LAR = new Zone(nameof(T_Z5LAR), 30);
        public static readonly Zone T_Z5RAL = new Zone(nameof(T_Z5RAL), 31);
        public static readonly Zone T_Z5RAM = new Zone(nameof(T_Z5RAM), 32);
        public static readonly Zone T_Z5RAR = new Zone(nameof(T_Z5RAR), 33);
        public static readonly Zone T_Z6 = new Zone(nameof(T_Z6), 34);
        public static readonly Zone T_Z7 = new Zone(nameof(T_Z7), 35);

        private Zone() : base(default, default) { }

        public Zone(string name, int value) : base(name, value) { }
    }
}
