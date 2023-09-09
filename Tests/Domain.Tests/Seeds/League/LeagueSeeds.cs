namespace Domain.Tests.Seeds.Leagues
{
    public class LeagueValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, "leagueName", 123456, 2 };
        }
    }
    public class LeagueInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null, null, null };
        }
    }
    public class UpdateLeagueValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "leagueName" };
        }
    }
    public class UpdateLeagueInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class UpdateLeagueNameValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "leagueName" };
        }
    }
    public class UpdateLeagueNameInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class UpdateLeagueParametersValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "regularPlaytime", "overPlaytime", true, true };
        }
    }
    public class AddLeagueParametersValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "regularPlaytime", "overPlaytime", true, true };
        }
    }
    public class AddGameModeDetailsValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, "regularPlaytime", "description", "value" };
        }
    }
    public class AddGameModeDetailsInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null, null, null };
        }
    }
    public class MapLeagueValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 4, 4 };
        }
    }
    public class UnMapLeagueValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 123456 };
        }
    }
}
