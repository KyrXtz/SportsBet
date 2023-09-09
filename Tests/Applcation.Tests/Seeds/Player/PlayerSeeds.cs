namespace Application.Tests.Seeds.Player
{
    public class CreateUpdatePlayerCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var position in PlayerPosition.List)
            {
                yield return new object[] {
                    new PlayerItem { Id = 1, Name = "existingPlayerName", Position = position, ProviderCountryId = 2 },
                    2,
                    "existingPlayerName2",
                    position,
                    2,
                    1,
                    1,
                    0
                };
            }

            foreach (var position in PlayerPosition.List)
            {
                yield return new object[] {
                    new PlayerItem { Id = 2, Name = "existingPlayerName", Position = position, ProviderCountryId = 2 },
                    2,
                    "existingPlayerName2",
                    position,
                    2,
                    1,
                    0,
                    1
                };
            }
        }
    }
    public class MapPlayerCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3, 1 };
        }
    }
    public class UnmapPlayerCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1,  1 };
        }
    }
}
