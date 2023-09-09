namespace SportsBet.Application.Commands.Matches;
public class UnmapMatchCommandValidator : AbstractValidator<UnmapMatchCommand>
{
    public UnmapMatchCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
    }
}