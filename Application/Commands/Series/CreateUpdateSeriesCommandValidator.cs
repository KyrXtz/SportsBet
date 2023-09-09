namespace SportsBet.Application.Commands.Series
{
    public class CreateUpdateSeriesCommandValidator : AbstractValidator<CreateUpdateSeriesCommand>
    {
        public CreateUpdateSeriesCommandValidator()
        {
            RuleForEach(x => x.Series).ChildRules(series =>
            {
                series.RuleFor(x => x.NumberOfMatches).NotEmpty().WithMessage("NumberOfMatches {CollectionIndex} is required");
                series.RuleFor(x => x.Team1Id).NotEmpty().WithMessage("Team1Id {CollectionIndex} is required");
                series.RuleFor(x => x.Team2Id).NotEmpty().WithMessage("Team2Id {CollectionIndex} is required");
            });
        }
    }
}
