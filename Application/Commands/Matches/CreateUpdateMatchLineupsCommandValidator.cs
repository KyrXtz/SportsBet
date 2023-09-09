namespace SportsBet.Application.Commands.Matches;
public class CreateUpdateMatchsLineupsCommandValidator : AbstractValidator<CreateUpdateMatchsLineupsCommand>
{
    public CreateUpdateMatchsLineupsCommandValidator()
    {
        RuleForEach(x => x.MatchLineups).ChildRules(matchStat =>
        {
            matchStat.RuleFor(x => x.MatchId).NotEmpty().WithMessage("MatchId {CollectionIndex} is required");
            matchStat.RuleFor(x => x.Type).NotEmpty().WithMessage("Type {CollectionIndex} is required");
            matchStat.RuleFor(x => x.CompetitorId).NotEmpty().WithMessage("CompetitorId {CollectionIndex} is required");
            matchStat.RuleFor(x => x.PlayerId).NotEmpty().WithMessage("PlayerId {CollectionIndex} is required");
            matchStat.RuleFor(x => x.SportId).NotEmpty().WithMessage("SportId {CollectionIndex} is required");
        });
    }
}