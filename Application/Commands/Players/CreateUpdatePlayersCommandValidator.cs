namespace SportsBet.Application.Commands.Players;
public class CreateUpdatePlayersCommandValidator : AbstractValidator<CreateUpdatePlayersCommand>
{
    public CreateUpdatePlayersCommandValidator()
    {
        RuleForEach(x => x.Players).ChildRules(player =>
        {
            player.RuleFor(x => x.Id).NotEmpty().WithMessage("Id {CollectionIndex} is required");
            player.RuleFor(x => x.Name).NotEmpty().WithMessage("Name {CollectionIndex} is required");
            player.RuleFor(x => x.Position).GreaterThanOrEqualTo(0).WithMessage("PlayerPosition {CollectionIndex} is required");
            player.RuleFor(x => x.ProviderCountryId).GreaterThanOrEqualTo(0).WithMessage("ProviderCountryId {CollectionIndex} is required");
        });
    }
}