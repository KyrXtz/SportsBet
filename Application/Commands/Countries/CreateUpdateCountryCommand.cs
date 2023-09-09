namespace SportsBet.Application.Commands.Countries
{
    public class CreateUpdateCountryCommand : CommandBase, IRequest<Result<List<long>>>
    {
        public IEnumerable<CountryItem> Countries { get; private set; }

        public CreateUpdateCountryCommand(IEnumerable<CountryItem> countries)
        {
            Countries = countries;
        }
    }

    public class CountryItem
    {
        public int ProviderId { get; set; }
        public string ISOCode { get; set; }
        public string Name { get; set; }
        public int SportId { get; set; }
    }
}
