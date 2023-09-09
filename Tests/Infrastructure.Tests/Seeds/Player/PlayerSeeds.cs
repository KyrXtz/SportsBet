namespace Infrastructure.Tests.Seeds.Player
{
    public class CreatePlayerValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var position in PlayerPosition.List)
            {
                yield return new object[] { 2, "playerName", position, 2 };
            }
        }
    }
    public class UpdatePlayerValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "playerName", "updatePlayerName" };
        }
    }
}
