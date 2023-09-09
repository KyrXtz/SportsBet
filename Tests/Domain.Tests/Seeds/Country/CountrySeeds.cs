namespace Domain.Tests.Seeds.Country
{
    public class CountryValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "iSOCode", "countryName", 1, 2 };
        }
    }
    public class CreateCountryInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, "", 0, 0 };
            yield return new object[] { null, null, null, null };
        }
    }
    public class UpdateCountryValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "iSOCode", "countryName", 3, 4 };
        }
    }

    public class UpdateCountryInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null, 3, 4 };
        }
    }
}
