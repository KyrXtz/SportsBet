namespace SportsBet.Application.Commands.Competitors
{
    public class MapCompetitorCommandValidator : AbstractValidator<MapCompetitorCommand>
    {
        public MapCompetitorCommandValidator()
        {
            RuleFor(x => x.BBCompetitorId).NotEmpty().WithMessage("BBCompetitionHistoryBetContextId {CollectionIndex} is required");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
            RuleFor(x => x.MappingAgentId).NotEmpty().WithMessage("MappingAgentId {CollectionIndex} is required");
        }
    }
}