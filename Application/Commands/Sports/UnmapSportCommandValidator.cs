namespace SportsBet.Application.Commands.Sports
{
    public class UnmapSportCommandValidator : AbstractValidator<UnmapSportCommand>
    {
        public UnmapSportCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
        }
    }
}