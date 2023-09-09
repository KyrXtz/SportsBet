namespace SportsBet.Application.Commands.Competitors
{
    public class UnmapCompetitorCommandValidator : AbstractValidator<UnmapCompetitorCommand>
    {
        public UnmapCompetitorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
        }
    }
}