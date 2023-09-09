namespace SportsBet.Application.Commands.MatchesEvents;
public class UpdateMatchsEventsCommandValidator : AbstractValidator<UpdateMatchsEventsCommand>
{
    public UpdateMatchsEventsCommandValidator()
    {
        RuleForEach(x => x.MatchSpecialEvents).ChildRules(matchSpecialEventEvent =>
        {
            matchSpecialEventEvent.RuleFor(x => x.MatchId).NotEmpty().WithMessage("MatchId {CollectionIndex} is required");
            matchSpecialEventEvent.RuleFor(x => x.EventNumber).GreaterThanOrEqualTo(0).WithMessage("EventNumber {CollectionIndex} is required");
        });
    }
}