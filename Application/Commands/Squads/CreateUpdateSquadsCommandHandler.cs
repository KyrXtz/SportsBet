namespace SportsBet.Application.Commands.Squads;
internal class CreateUpdateSquadsCommandHandler : IRequestHandler<CreateUpdateSquadsCommand, Result<List<long>>>
{
    private readonly IRepository<Squad> _repository;

    public CreateUpdateSquadsCommandHandler(IRepository<Squad> repository)
    {
        _repository = repository;
    }
    public async Task<Result<List<long>>> Handle(CreateUpdateSquadsCommand request, CancellationToken cancellationToken)
    {
        var competitorIds = request.Squads.Select(p => p.CompetitorId).ToArray();
        var playerIds = request.Squads.Select(p => p.PlayerId).ToArray();

        var existingSquads = await _repository.ListAsync(new GetSquadsByCompetitorAndPlayerIdsSpecification(competitorIds, playerIds));

        var newSquads = new List<Squad>();
        var updSquads = new List<Squad>();

        foreach (var squad in request.Squads)
        {
            var existingSquad = existingSquads.FirstOrDefault(s => s.CompetitorId == squad.CompetitorId && s.PlayerId == squad.PlayerId);

            if (existingSquad != null)
            {
                var squadInfo = SquadInfo.Create(rating: PlayerRating.FromValue(squad.Rating), jerseyNumber: squad.JerseyNumber);

                if (!existingSquad.Info.Equals(squadInfo))
                {
                    existingSquad.UpdateInfo(squadInfo);
                    updSquads.AddUniqueItem(existingSquad);
                }

                continue;
            }

            newSquads.Add(Squad.Create(rating: PlayerRating.FromValue(squad.Rating),
                jerseyNumber: squad.JerseyNumber,
                competitorId: squad.CompetitorId,
                playerId: squad.PlayerId));
        }

        if (!newSquads.Any() && !updSquads.Any())
            return Result<List<long>>.Success("No Squads Added or Updated");

        var returnLst = new List<long>();

        if (newSquads.Any())
        {
            await _repository.AddRangeAsync(newSquads);
            returnLst.AddRange(newSquads.Select(p => p.Id).ToList());
        }

        if (updSquads.Any())
        {
            await _repository.UpdateRangeAsync(updSquads);
            returnLst.AddRange(updSquads.Select(p => p.Id).ToList());
        }

        return Result<List<long>>.Success(returnLst);
    }
}