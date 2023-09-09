namespace SportsBet.Application.Commands.Sports
{
    public class CreateUpdateSportCommand : CommandBase, IRequest<Result<List<int>>>
    {
        public IEnumerable<SportItem> Sports { get; private set; }

        public CreateUpdateSportCommand(IEnumerable<SportItem> sports)
        {
            Sports = sports;
        }
    }

    public class SportItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}