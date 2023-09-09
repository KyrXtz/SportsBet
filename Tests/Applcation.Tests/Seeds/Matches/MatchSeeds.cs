namespace Application.Tests.Seeds.Matches
{
    public class CreateUpdateMatchsCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var status in MatchStatus.List)
            {
                yield return new object[] {
                    new MatchItem {
                        Id = 1,
                        Name = "existingMatchName",
                        Status = status,
                        Date = DateTime.Now,
                        HomeCompetitorId = 1,
                        AwayCompetitorId = 1,
                        SportId = 1,
                        LeagueId = 1,
                    },
                    1,
                    "existingMatchName2",
                    status,
                    DateTime.Now,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    0,
                    1
                };
            }

            foreach (var status in MatchStatus.List)
            {
                yield return new object[] {
                    new MatchItem {
                        Id = 1,
                        Name = "existingMatchName",
                        Status = status,
                        Date = DateTime.Now,
                        HomeCompetitorId = 1,
                        AwayCompetitorId = 1,
                        SportId = 1,
                        LeagueId = 1,
                    },
                    2,
                    "existingMatchName2",
                    status,
                    DateTime.Now,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    1,
                    0
                };
            }
        }
    }
    public class MapMatchsCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3, 1 };
        }
    }
    public class UnmapMatchsCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 1 };
        }
    }
    public class AddMatchsEventsCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var status in MatchStatus.List)
            {
                yield return new object[] {
                    1,
                    "existingMatchName2",
                    status,
                    DateTime.Now,
                    1,
                    1,
                    1,
                    1,
                    1,
                    new MatchEventItem {
                        MatchId = 2,
                        EventCodeId = 2,
                        EventNumber = 2,
                        EventCode = "eventCode",
                        MatchStateId = 2,
                        Minute = 2,
                        Timestamp = 123456,
                        ClockRunning = true
                    },
                    1,
                    0,
                    1
                    };
            }
        }
    }
    public class CreateUpdateMatchsLineupsCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var status in MatchStatus.List)
            {
                yield return new object[] {
                    1,
                    "existingMatchName2",
                    status,
                    DateTime.Now,
                    1,
                    1,
                    1,
                    1,
                    1,
                    new MatchLineupItem {
                        MatchId = 2,
                        Type = 2,
                        CompetitorId = 2,
                        PlayerId = 2,
                        SportId = 2
                    },
                    1,
                    0,
                    1
                    };
            }
        }
    }
    public class CreateUpdateMatchsStatsCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            foreach (var status in MatchStatus.List)
            {
                yield return new object[] {
                    1,
                    "existingMatchName2",
                    status,
                    DateTime.Now,
                    1,
                    1,
                    1,
                    1,
                    1,
                    new MatchStatItem {
                        MatchId = 2,
                        EventId = 2,
                        Value = "value",
                        CompetitorId = 2,
                        PlayerId = 2
                    },
                    1,
                    0,
                    1
                    };
            }
        }
    }
}
