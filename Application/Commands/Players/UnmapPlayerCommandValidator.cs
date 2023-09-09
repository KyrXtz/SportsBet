namespace SportsBet.Application.Commands.Players
{
    public class UnmapPlayerCommandValidator : AbstractValidator<UnmapPlayerCommand>
    {
        public UnmapPlayerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
        }
    }
}