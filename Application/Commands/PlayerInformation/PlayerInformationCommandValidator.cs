namespace SportsBet.Application.Commands.PlayerInformation;
public class PlayerInformationCommandValidator : AbstractValidator<PlayerInformationCommand>
{
    public PlayerInformationCommandValidator()
    {
        RuleFor(x => x.Payload).NotEmpty().WithMessage("Request {CollectionIndex} is required");
    }
}