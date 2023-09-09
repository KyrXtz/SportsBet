namespace Application.Tests.Seeds.Competitor
{
    public class CreateUpdateCompetitorCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new CompetitorItem { Id = 2, Name = "existingCompetitorName", IsIndividual = true, SportId = 2, CountryId = 2 },
                    "existingCompetitorName",
                    1,
                    1,
                    0
            };

            yield return new object[] {
                    new CompetitorItem { Id = 1, Name = "existingCompetitorName", IsIndividual = true, SportId = 3, CountryId = 3 },
                    "existingCountryName3",
                    1,
                    0,
                    1
            };
        }
    }
    public class MapCompetitorCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3, 1 };
        }
    }
    public class UnmapCompetitorCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1 };
        }
    }
}
