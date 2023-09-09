namespace Infrastructure.Tests.Seeds.Country
{
    public class CreateCountryValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "countryName" };
        }
    }
    public class UpdateCountryValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "iSOCode", "countryName", 1, 2, "updatedISOCode", "UpdatedCountryName" };
        }
    }
}
