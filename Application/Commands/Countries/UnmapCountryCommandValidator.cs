namespace SportsBet.Application.Commands.Countries
{
    public class UnmapCountryCommandValidator : AbstractValidator<UnmapCountryCommand>
    {
        public UnmapCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
        }
    }
}