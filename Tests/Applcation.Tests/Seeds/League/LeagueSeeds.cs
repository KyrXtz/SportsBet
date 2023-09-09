namespace Application.Tests.Seeds.League
{
    public class CreateUpdateLeagueCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new LeagueItem { Id = 1, Name = "leagueName", CountryId = 1 ,SportId = 1 },
                    1,
                    "existingLeagueName",
                    1,
                    1,
                    1,
                    0,
                    1
            };

            yield return new object[] {
                    new LeagueItem { Id = 1, Name = "existingLeagueName", CountryId = 1 ,SportId = 1 },
                    2,
                    "existingLeagueName",
                    1,
                    1,
                    1,
                    1,
                    0
            };
        }
    }
    public class MapLeagueCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 2, 1 };
        }
    }
    public class UnmapLeagueCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1 };
        }
    }
}
