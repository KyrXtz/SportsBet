namespace Infrastructure.Tests.Seeds.League
{
    public class CreateLeagueValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, "leagueName", 123456, 2 };
        }
    }
    public class UpdateLeagueValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "leagueName", "updatedLeagueName" };
        }
    }
}
