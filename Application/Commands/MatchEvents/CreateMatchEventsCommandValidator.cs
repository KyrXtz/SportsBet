namespace SportsBet.Application.Commands.MatchesEvents;
public class CreateMatchsEventsCommandValidator : AbstractValidator<CreateMatchsEventsCommand>
{
    public CreateMatchsEventsCommandValidator()
    {
        RuleForEach(x => x.MatchEvents).ChildRules(matchEvent =>
        {
            matchEvent.RuleFor(x => x.MatchId).NotEmpty().WithMessage("MatchId {CollectionIndex} is required");
            matchEvent.RuleFor(x => x.EventCodeId).GreaterThanOrEqualTo(0).WithMessage("EventCodeId {CollectionIndex} is required");
            matchEvent.RuleFor(x => x.EventNumber).GreaterThanOrEqualTo(0).WithMessage("EventNumber {CollectionIndex} is required");
            matchEvent.RuleFor(x => x.EventCode).NotEmpty().WithMessage("EventCode {CollectionIndex} is required");
            matchEvent.RuleFor(x => x.MatchStateId).GreaterThanOrEqualTo(0).WithMessage("State {CollectionIndex} is required");
            matchEvent.RuleFor(x => x.Minute).GreaterThanOrEqualTo(0).WithMessage("Minute {CollectionIndex} is required");
            matchEvent.RuleFor(x => x.MatchId).NotEmpty().WithMessage("MatchId {CollectionIndex} is required");
        });
    }
}