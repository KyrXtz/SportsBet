namespace SportsBet.Application.Commands.GameList;

public class GameListCommandValidator : AbstractValidator<GameListCommand>
{
    public GameListCommandValidator()
    {
        //RuleFor(x => x.Request).NotEmpty().WithMessage("Request {CollectionIndex} is required");
    }
}