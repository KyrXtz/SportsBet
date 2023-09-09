namespace SportsBet.Application.Commands.Sports
{
    internal class CreateUpdateSportCommandHandler : IRequestHandler<CreateUpdateSportCommand, Result<List<int>>>
    {
        private readonly IRepository<Sport> _sportsRepository;

        public CreateUpdateSportCommandHandler(IRepository<Sport> repository)
        {
            _sportsRepository = repository;
        }
        public async Task<Result<List<int>>> Handle(CreateUpdateSportCommand request, CancellationToken cancellationToken)
        {
            var existingSports = await _sportsRepository.ListAsync(new GetSportsByIdsSpecification(request.Sports.Select(p => p.Id).ToArray()));

            var newSports = new List<Sport>();
            var updSports = new List<Sport>();

            foreach (var sport in request.Sports)
            {
                var existingSport = existingSports.FirstOrDefault(p => p.Id == sport.Id);

                if (existingSport != null)
                {
                    var sportName = SportName.Create(name: sport.Name);

                    if (!existingSport.Name.Equals(sportName))
                    {
                        existingSport.UpdateSportName(sportName);
                        updSports.AddUniqueItem(existingSport);
                    }

                    continue;
                }

                newSports.Add(Sport.Create(id: sport.Id, name: sport.Name));
            }

            if (!newSports.Any() && !updSports.Any())
                return Result<List<int>>.Fail();

            var returnLst = new List<int>();

            if (newSports.Any())
            {
                await _sportsRepository.AddRangeAsync(newSports);
                returnLst.AddRange(newSports.Select(p => p.Id).ToList());
            }

            if (updSports.Any())
            {
                await _sportsRepository.UpdateRangeAsync(updSports);
                returnLst.AddRange(updSports.Select(p => p.Id).ToList());
            }

            return Result<List<int>>.Success(returnLst);
        }
    }
}
