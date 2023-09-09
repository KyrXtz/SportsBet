global using SportsBet.Domain.Enums.Matches;
using SportsBet.Domain.Aggregates.Matches;
using SportsBet.Domain.ValueObjects.Matches;

namespace Domain.Tests.Seeds.Match
{
    public class MatchValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { 1, "match", matchStatus, DateTime.Now, 1, 1, 1, 0, 0 };
            }
        }
    }

    public class MatchInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { null, null, null, null, null, null, null, null, null };
            }
        }
    }

    public class UpdateMatchValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { "match", matchStatus, DateTime.Now, 1, 1 };
            }
        }
    }

    public class UpdateMatchInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { null, null, null, null, null };
            }
        }
    }

    public class UpdateMatchNameValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { "name" };
            }
        }
    }

    public class UpdateMatchNameInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { "" };
            }
        }
    }

    public class UpdateMatchStatusValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { MatchStatus.Open };
            }
        }
    }

    public class UpdateMatchStatusInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { MatchStatus.FromValue(0) };
            }
        }
    }

    public class UpdateMatchDateValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { DateTime.Now };
            }
        }
    }

    public class UpdateMatchDateInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { null };
            }
        }
    }
    public class UpdateMatchCompetitorsValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var matchStatus in MatchStatus.List)
            {
                yield return new object[] { 1, 1 };
            }
        }
    }

    public class UpdateMatchCompetitorsInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[] { "as", " b" };
        }
    }

    public class AddMatchDetailsValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[] { 1, "2", "description", "value" };
        }
    }

    public class AddMatchDetailsInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {

            yield return new object[] { null, "", "", "" };
        }
    }

    public class AddOrUpdateLineupValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { MatchLineupType.Bench, 1, 1, 1, true };
        }
    }

    public class AddOrUpdateLineupInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { MatchLineupType.Bench, null, null, null };
        }
    }

    public class AddOrUpdateStatsValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, "1", 1, 1 };
        }
    }

    public class AddOrUpdateStatsInvalidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { null, "", null, null };
        }
    }

    public class UpdateScoreValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2 };
        }
    }


    public class MatchMapValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, DateTime.Now };
        }
    }

    public class MatchUnMapValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, DateTime.Now };
        }
    }
}

