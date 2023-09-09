namespace SportsBet.Application.Commands.Squads;
public class CreateUpdateSquadsCommandValidator : AbstractValidator<CreateUpdateSquadsCommand>
{
    public CreateUpdateSquadsCommandValidator()
    {
        RuleForEach(x => x.Squads).ChildRules(squad =>
        {
            squad.RuleFor(x => x.CompetitorId).NotEmpty().WithMessage("CompetitorId {CollectionIndex} is required");
            squad.RuleFor(x => x.PlayerId).NotEmpty().WithMessage("PlayerId {CollectionIndex} is required");
            squad.RuleFor(x => x.Rating).GreaterThanOrEqualTo(0).WithMessage("Rating {CollectionIndex} is required");
        });
    }
}