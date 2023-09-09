namespace SportsBet.Application.Commands.Competitors
{
    public class MapCompetitorCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int Id { get; private set; }
        public int BBCompetitorId { get; private set; }
        public int MappingAgentId { get; private set; }

        public MapCompetitorCommand(int id,int bBCompetitorId,int mappingAgentId)
        {
            Id = id;
            BBCompetitorId = bBCompetitorId;
            MappingAgentId = mappingAgentId;
        }
    }
}