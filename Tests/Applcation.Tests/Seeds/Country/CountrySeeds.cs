namespace Application.Tests.Seeds.Country
{
    public class CreateUpdateCountryCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new CountryItem { ProviderId = 2, ISOCode = "iSOCode", Name = "existingCountryName", SportId = 2 },
                    "iSOCode2",
                    "existingCountryName2",
                    2,
                    2,
                    1,
                    0,
                    1
            };

            yield return new object[] {
                    new CountryItem { ProviderId = 1, ISOCode = "iSOCode3", Name = "existingCountryName3", SportId = 1 },
                    "iSOCode3",
                    "existingCountryName3",
                    2,
                    2,
                    1,
                    1,
                    0
            };
        }
    }
    public class MapCountryCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 1 };
        }
    }
    public class UnmapCountryCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1 };
        }
    }
}
