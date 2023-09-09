namespace SportsBet.Application.Commands.Players
{
    public class MapPlayerCommandValidator : AbstractValidator<MapPlayerCommand>
    {
        public MapPlayerCommandValidator()
        {
            RuleFor(x => x.BBPlayerId).NotEmpty().WithMessage("BBPlayerId {CollectionIndex} is required");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
            RuleFor(x => x.MappingAgentId).NotEmpty().WithMessage("MappingAgentId {CollectionIndex} is required");
        }
    }
}