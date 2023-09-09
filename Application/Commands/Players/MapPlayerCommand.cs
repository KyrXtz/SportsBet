namespace SportsBet.Application.Commands.Players
{
    public class MapPlayerCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int Id { get; private set; }
        public int BBPlayerId { get; private set; }
        public int MappingAgentId { get; private set; }
        public MapPlayerCommand(int id, int bBPlayerId, int mappingAgentId)
        {
            Id = id;
            BBPlayerId = bBPlayerId;
            MappingAgentId = mappingAgentId;
        }
    }
}