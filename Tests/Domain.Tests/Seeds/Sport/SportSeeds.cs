namespace Domain.Tests.Seeds.Sport
{
    public class SportValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "sportName" };
        }
    }
    public class SportInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null };
        }
    }

    public class UpdateSportValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "sportName" };
        }
    }
    public class UpdateSportInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class UpdateSportNameValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "sportName" };
        }
    }
    public class UpdateSportNameInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class MapSportValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 4, 4 };
        }
    }
    public class UnMapSportValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 123456 };
        }
    }
}
