namespace SportsBet.Application.Commands.Countries
{
    public class MapCountryCommandValidator : AbstractValidator<MapCountryCommand>
    {
        public MapCountryCommandValidator()
        {
            RuleFor(x => x.BBRegionId).NotEmpty().WithMessage("BBRegionId {CollectionIndex} is required");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
            RuleFor(x => x.MappingAgentId).NotEmpty().WithMessage("MappingAgentId {CollectionIndex} is required");
        }
    }
}