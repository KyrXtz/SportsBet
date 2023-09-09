namespace SportsBet.Application.Commands.Sports
{
    public class CreateUpdateSportCommandValidator : AbstractValidator<CreateUpdateSportCommand>
    {
        public CreateUpdateSportCommandValidator()
        {
            RuleForEach(x => x.Sports).ChildRules(sport =>
            {
                sport.RuleFor(x => x.Id).GreaterThanOrEqualTo(0).WithMessage("Id {CollectionIndex} is required");
                sport.RuleFor(x => x.Name).NotEmpty().WithMessage("Name {CollectionIndex} is required");
            });
        }
    }
}
