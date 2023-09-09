namespace SportsBet.Application.Commands.Competitors
{
    public class CreateUpdateCompetitorCommand : CommandBase, IRequest<Result<List<int>>>
    {
        public IEnumerable<CompetitorItem> Competitors { get; private set; }

        public CreateUpdateCompetitorCommand(IEnumerable<CompetitorItem> competitors)
        {
            Competitors = competitors;
        }
    }

    public class CompetitorItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsIndividual { get; set; }
        public int SportId { get; set; }
        public long CountryId { get; set; }
    }
}