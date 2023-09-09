namespace SportsBet.Application.Commands.Matches
{
    public class CreateUpdateMatchsCommandValidator : AbstractValidator<CreateUpdateMatchsCommand>
    {
        public CreateUpdateMatchsCommandValidator()
        {
            RuleForEach(x => x.Matches).ChildRules(match =>
            {
                match.RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
                match.RuleFor(x => x.Name).NotEmpty().WithMessage("Name {CollectionIndex} is required");
                //match.RuleFor(x => x.Status).NotEmpty().WithMessage("Status {CollectionIndex} is required");
                match.RuleFor(x => x.Date).NotEmpty().WithMessage("Date {CollectionIndex} is required");
                match.RuleFor(x => x.HomeCompetitorId).NotEmpty().WithMessage("HomeCompetitorId {CollectionIndex} is required");
                match.RuleFor(x => x.AwayCompetitorId).NotEmpty().WithMessage("AwayCompetitorId {CollectionIndex} is required");
                match.RuleFor(x => x.SportId).NotEmpty().WithMessage("SportId {CollectionIndex} is required");
                match.RuleFor(x => x.LeagueId).NotEmpty().WithMessage("LeagueId {CollectionIndex} is required");
            });
        }
    }
}