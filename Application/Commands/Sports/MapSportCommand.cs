namespace SportsBet.Application.Commands.Sports
{
    public class MapSportCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int Id { get; private set; }
        public int BBCompetitionContextId { get; private set; }
        public int MappingAgentId { get; private set; }

        public MapSportCommand(int id, int bBCompetitionContextId, int mappingAgentId)
        {
            Id = id;
            BBCompetitionContextId = bBCompetitionContextId;
            MappingAgentId = mappingAgentId;
        }
    }
}