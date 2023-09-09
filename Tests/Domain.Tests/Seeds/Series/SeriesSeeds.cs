namespace Domain.Tests.Seeds.Series
{
    public class SeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        }
    }
    public class SeriesInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null, null, null, null, null, null, null, null };
        }
    }
    public class UpdateSeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 2, 2, 2, 2, 2 }; 
        }
    }
    public class UpdateSeriesInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -2, -2, -2, -2, -2, -2, -2 };
        }
    }
    public class CreateUpdateTeamOneSeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2 };
        }
    }
    public class CreateUpdateTeamOneSeriesInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class CreateUpdateTeamTwoSeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2 };
        }
    }
    public class CreateUpdateTeamTwoSeriesInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class CreateUpdateScoreOneSeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2 };
        }
    }
    public class CreateUpdateScoreOneSeriesInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -1, -1 }; 
        }
    }
    public class CreateUpdateScoreTwoSeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2 };
        }
    }
    public class CreateUpdateScoreTwoSeriesInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -1, -1 };
        }
    }
    public class UpdateWinnerSeriesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2 };
        }
    }
    public class UpdateWinnerSeriesInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -2 };
        }
    }
    public class UpdateSeriesInfoValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2 };
        }
    }
    public class UpdateSeriesInfoInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null };
        }
    }
    public class AddSeriesMatchValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2 };
        }
    }
    public class AddSeriesMatchInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { -2, -2 };
        }
    }
    public class UpdateSeriesMatchScoresValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 2, 2, 2, 2 };
        }
    }
    public class UpdateSeriesMatchScoresInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null, null, null, null, null };
        }
    }
    public class UpdateSeriesMatchScore1ValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 2, 2 };
        }
    }
    public class UpdateSeriesMatchScore1InValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null, null, null };
        }
    }
    public class UpdateSeriesMatchScore2ValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2, 2, 2 };
        }
    }
    public class UpdateSeriesMatchScore2InValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null, null, null };
        }
    }
    public class AddOrUpdateSeriesMatchesValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 2 };
        }
    }
    public class AddOrUpdateSeriesMatchesInValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, null };
        }
    }
}
