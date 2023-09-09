namespace SportsBet.Application.Commands.Leagues
{
    public class MapLeagueCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int Id { get; private set; }
        public int BBLeagueId { get; private set; }
        public int MappingAgentId { get; private set; }

        public MapLeagueCommand(int id, int bBLeagueId, int mappingAgentId)
        {
            Id = id;
            BBLeagueId = bBLeagueId;
            MappingAgentId = mappingAgentId;
        }
    }
}