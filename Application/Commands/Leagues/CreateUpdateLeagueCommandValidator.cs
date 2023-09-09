namespace SportsBet.Application.Commands.Leagues
{
    public class CreateUpdateLeagueCommandValidator : AbstractValidator<CreateUpdateLeagueCommand>
    {
        public CreateUpdateLeagueCommandValidator()
        {
            RuleForEach(x => x.Leagues).ChildRules(league =>
            {
                league.RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
                league.RuleFor(x => x.Name).NotEmpty().WithMessage("Name {CollectionIndex} is required");
                league.RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId {CollectionIndex} is required");
                league.RuleFor(x => x.SportId).NotEmpty().WithMessage("SportId {CollectionIndex} is required");
            });
        }
    }
}