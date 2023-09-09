namespace SportsBet.Application.Commands.Leagues
{
    public class UnmapLeagueCommandValidator : AbstractValidator<UnmapLeagueCommand>
    {
        public UnmapLeagueCommandValidator()
        {
         RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
        }
    }
}