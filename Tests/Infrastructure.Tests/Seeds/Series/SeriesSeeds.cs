namespace Infrastructure.Tests.Seeds.Series
{
    public class CreateSeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        }
    }
    public class UpdateSeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4 };
        }
    }
}
