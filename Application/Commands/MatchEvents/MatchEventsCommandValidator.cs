namespace SportsBet.Application.Commands.MatchesEvents;
public class MatchsEventsCommandValidator : AbstractValidator<MatchsEventsCommand>
{
    public MatchsEventsCommandValidator()
    {
        RuleFor(x => x.Payload).NotEmpty().WithMessage("Request {CollectionIndex} is required");
    }
}
