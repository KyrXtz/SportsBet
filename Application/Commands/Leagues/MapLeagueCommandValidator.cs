namespace SportsBet.Application.Commands.Leagues
{
    public class MapLeagueCommandValidator : AbstractValidator<MapLeagueCommand>
    {
        public MapLeagueCommandValidator()
        {
            RuleFor(x => x.BBLeagueId).NotEmpty().WithMessage("BBLeagueId {CollectionIndex} is required");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
            RuleFor(x => x.MappingAgentId).NotEmpty().WithMessage("MappingAgentId {CollectionIndex} is required");
        }
    }
}