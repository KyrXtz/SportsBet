namespace SportsBet.Application.Commands.Sports
{
    public class MapSportCommandValidator : AbstractValidator<MapSportCommand>
    {
        public MapSportCommandValidator()
        {
            RuleFor(x => x.BBCompetitionContextId).NotEmpty().WithMessage("BBCompetitionContextId {CollectionIndex} is required");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
            RuleFor(x => x.MappingAgentId).NotEmpty().WithMessage("MappingAgentId {CollectionIndex} is required");
        }
    }
}