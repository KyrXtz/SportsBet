namespace Application.Tests.Seeds.Sport
{
    public class CreateUpdateSportCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new SportItem { Id = 1, Name = "sportToCreateUpdate" },
                    2, //existing sport Id
                    "existingSportName",
                    1,
                    1,
                    0
            };

            yield return new object[] {
                    new SportItem { Id = 2, Name = "sportToCreateUpdate" },
                    2, //existing sport Id
                    "existingSportName",
                    1,
                    0,
                    1
            };
        }
    }
    public class MapSportCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3, 1 };


        }
    }
    public class UnmapSportCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1 };
        }
    }
}