namespace SportsBet.Application.Commands.Countries
{
    public class MapCountryCommand : CommandBase, IRequest<Result<Unit>>
    {
        public long Id { get; private set; }
        public int BBRegionId { get; private set; }
        public int MappingAgentId { get; private set; }
        public MapCountryCommand(long id, int bBRegionId, int mappingAgentId)
        {
            Id = id;
            BBRegionId = bBRegionId;
            MappingAgentId = mappingAgentId;
        }
    }  
}