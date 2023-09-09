using static SportsBet.Application.Commands.Series.SeriesItem;

namespace Application.Tests.Seeds.Series
{
    public class CreateUpdateSeriesCommandValidSeed : Seed, IEnumerable<object[]>
    {
        public override IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new SeriesItem {
                        Id = 123456789,
                        NumberOfMatches = 2,
                        Team1Id = 1,
                        Team1Score = 2,
                        Team1Standing = 2,
                        Team2Id = 1,
                        Team2Score = 2,
                        Team2Standing = 2,
                        WinnerTeamId = 1,
                        SeriesMatches = new List<SeriesMatchItem>()
                        {
                            new SeriesMatchItem {
                                    Leg = 2,
                                    MatchId = 2,
                                    Score1 = 2,
                                    Standing1 = 2,
                                    Score2 = 2,
                                    Standing2 = 2
                            }
                        },
                    },
                    2, 2, 2, 2, 2, 2, 2, 1, 2, 2, 1, 0, 1
            };

            yield return new object[] {
                    new SeriesItem {
                        Id = 123456789,
                        NumberOfMatches = 2,
                        Team1Id = 1,
                        Team1Score = 2,
                        Team1Standing = 2,
                        Team2Id = 1,
                        Team2Score = 2,
                        Team2Standing = 2,
                        WinnerTeamId = 1,
                        SeriesMatches = new List<SeriesMatchItem>()
                        {
                            new SeriesMatchItem {
                                    Leg = 2,
                                    MatchId = 2,
                                    Score1 = 2,
                                    Standing1 = 2,
                                    Score2 = 2,
                                    Standing2 = 2
                            }
                        },
                    },
                    2, 2, 2, 2, 2, 2, 2, 1, 0, 0, 1, 1, 0
            };
        }
    }
}
