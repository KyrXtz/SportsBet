namespace Infrastructure.Tests.Seeds.Match
{
    public class CreateMatchValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { 1, "match", matchStatus, DateTime.Now, 1, 1, 1, 0, 0 };
            }
        }
    }

    public class UpdateMatchValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { 1, "match", "updatedMatchName", matchStatus, DateTime.Now, 1, 1, 1, 0, 0 };
            }
        }
    }
}
