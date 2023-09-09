namespace SportsBet.Application.Commands.Players;

class CreateUpdatePlayersCommandHandler : IRequestHandler<CreateUpdatePlayersCommand, Result<List<int>>>
{
    private readonly IRepository<Player> _repository;

    public CreateUpdatePlayersCommandHandler(IRepository<Player> repository)
    {
        _repository = repository;
    }
    public async Task<Result<List<int>>> Handle(CreateUpdatePlayersCommand request, CancellationToken cancellationToken)
    {
        var playerIds = request.Players.Select(p => p.Id).ToArray();

        var existingPlayers = await _repository.ListAsync(new GetPlayersByIdsSpecification(playerIds));

        var newPlayers = new List<Player>();
        var updPlayers = new List<Player>();

        foreach (var player in request.Players)
        {
            if (newPlayers.SingleOrDefault(p => p.Id == player.Id) != null)
                continue;

            var existingPlayer = existingPlayers.SingleOrDefault(p => p.Id == player.Id);

            if (existingPlayer != null)
            {
                var playerName = PlayerName.Create(name: player.Name);
                   
                if (!existingPlayer.Name.Equals(playerName))
                {
                    existingPlayer.UpdatePlayerName(playerName);
                    updPlayers.AddUniqueItem(existingPlayer);
                }

                if (!existingPlayer.Position.Equals(PlayerPosition.FromValue(player.Position)))
                {
                    existingPlayer.UpdatePlayerPosition(PlayerPosition.FromValue(player.Position));
                    updPlayers.AddUniqueItem(existingPlayer);
                }

                continue;
            }
                    
            newPlayers.Add(Player.Create(
                id: player.Id,
                name: player.Name,
                position: PlayerPosition.FromValue(player.Position),
                providerCountryId: player.ProviderCountryId
                ));
        }

        if (!newPlayers.Any() && !updPlayers.Any())
            return Result<List<int>>.Success("No Player Data Added or Updated");

        var returnLst = new List<int>();

        if (newPlayers.Any())
        {
            await _repository.AddRangeAsync(newPlayers);
            returnLst.AddRange(newPlayers.Select(p => p.Id).ToList());
        }

        if (updPlayers.Any())
        {
            await _repository.UpdateRangeAsync(updPlayers);
            returnLst.AddRange(updPlayers.Select(p => p.Id).ToList());
        }

        return Result<List<int>>.Success(returnLst);
    }
}