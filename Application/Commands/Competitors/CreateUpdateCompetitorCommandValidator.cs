namespace SportsBet.Application.Commands.Competitors
{
    public class CreateUpdateCompetitorCommandValidator : AbstractValidator<CreateUpdateCompetitorCommand>
    {
        public CreateUpdateCompetitorCommandValidator()
        {
            RuleForEach(x => x.Competitors).ChildRules(competitor =>
            {
                competitor.RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
                competitor.RuleFor(x => x.Name).NotEmpty().WithMessage("Name {CollectionIndex} is required");
                competitor.RuleFor(x => x.IsIndividual).NotNull().WithMessage("IsIndividual {CollectionIndex} is required");
                competitor.RuleFor(x => x.SportId).NotEmpty().WithMessage("SportId {CollectionIndex} is required");
                competitor.RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId {CollectionIndex} is required");
            });
        }
    }
}
