namespace SportsBet.Application.Commands.Matches
{
    public class CreateUpdateMatchsStatsCommandValidator : AbstractValidator<CreateUpdateMatchsStatsCommand>
    {
        public CreateUpdateMatchsStatsCommandValidator()
        {
            RuleForEach(x => x.MatchStats).ChildRules(matchStat =>
            {
                matchStat.RuleFor(x => x.MatchId).NotEmpty().WithMessage("MatchId {CollectionIndex} is required");
                matchStat.RuleFor(x => x.EventId).NotEmpty().WithMessage("EventId {CollectionIndex} is required");
                matchStat.RuleFor(x => x.Value).NotEmpty().WithMessage("Value {CollectionIndex} is required");
                matchStat.RuleFor(x => x.CompetitorId).NotEmpty().WithMessage("CompetitorId {CollectionIndex} is required");
            });
        }
    }
}