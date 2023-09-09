using Unit = MediatR.Unit;

namespace SportsBet.Application.Commands.Matches
{
    public class UpdateMatchStatusCommand : CommandBase, IRequest<Result<Unit>>
    {
        public int BetContextId { get; private set; }
        public MatchStatus Status { get; private set; }

        public UpdateMatchStatusCommand(int betContextId, MatchStatus status)
        {
            BetContextId = betContextId;
            Status = status;
        }
    }
}

