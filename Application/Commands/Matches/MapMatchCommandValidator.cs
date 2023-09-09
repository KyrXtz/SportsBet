namespace SportsBet.Application.Commands.Matches;
public class MapMatchCommandValidator : AbstractValidator<MapMatchCommand>
{
    public MapMatchCommandValidator()
    {
        RuleFor(x => x.BBEventHistoryId).NotEmpty().WithMessage("BBEventHistoryId {CollectionIndex} is required");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
        RuleFor(x => x.MappingAgentId).NotEmpty().WithMessage("MappingAgentId {CollectionIndex} is required");
    }
}