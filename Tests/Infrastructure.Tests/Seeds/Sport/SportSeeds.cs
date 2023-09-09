namespace Infrastructure.Tests.Seeds.Sport
{
    public class CreateSportValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "sportName" };
        }
    }
    public class UpdateSportValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "sportName", "UpdatedSportName" };
        }
    }
}
