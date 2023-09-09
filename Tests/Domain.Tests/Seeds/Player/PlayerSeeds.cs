namespace Domain.Tests.Seeds.Player
{
    public class PlayerValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var position in PlayerPosition.List)
            {
                yield return new object[] { 2, "playerName", position, 2 };
            }
        }
    }
    public class PlayerInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var position in PlayerPosition.List)
            {
                yield return new object[] { null, null, null, null };
            }
        }
    }
    public class UpdatePlayerValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "playerName" };
        }
    }
    public class UpdatePlayerInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class UpdatePlayerNameValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "playerName" };
        }
    }
    public class UpdatePlayerNameInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class MapPlayerValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 4, 4 };
        }
    }
    public class UnMapPlayerValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 123456 };
        }
    }
}
