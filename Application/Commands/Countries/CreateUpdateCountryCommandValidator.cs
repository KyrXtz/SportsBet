namespace SportsBet.Application.Commands.Countries;
public class CreateUpdateCountryCommandValidator : AbstractValidator<CreateUpdateCountryCommand>
{
    public CreateUpdateCountryCommandValidator()
    {
        RuleForEach(x => x.Countries).ChildRules(country =>
        {
            country.RuleFor(x => x.ProviderId).GreaterThanOrEqualTo(0).WithMessage("ProviderId {CollectionIndex} is required");
            country.RuleFor(x => x.SportId).NotEmpty().WithMessage("SportId {CollectionIndex} is required");
            //country.RuleFor(x => x.ISOCode).NotEmpty().WithMessage("Code {CollectionIndex} is required");
            country.RuleFor(x => x.Name).NotEmpty().WithMessage("Name {CollectionIndex} is required");
        });
    }
}