namespace SportsBet.Application.Commands.Matches;
public class MapMatchCommand : CommandBase, IRequest<Result<Unit>>
{
    public int Id { get; private set; }
    public int BBEventHistoryId { get; private set; }
    public int MappingAgentId { get; private set; }
    public MapMatchCommand(int id, int bBEventHistoryId, int mappingAgentId)
    {
        Id = id;
        BBEventHistoryId = bBEventHistoryId;
        MappingAgentId = mappingAgentId;
    }
}