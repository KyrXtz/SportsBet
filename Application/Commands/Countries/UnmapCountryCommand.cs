namespace SportsBet.Application.Commands.Countries
{
    public class UnmapCountryCommand : CommandBase, IRequest<Result<Unit>>
    {
        public long Id { get; private set; }

        public UnmapCountryCommand(long id)
        {
            Id = id;
        }
    }
}
