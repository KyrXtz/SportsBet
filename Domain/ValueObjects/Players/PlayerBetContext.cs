namespace SportsBet.Domain.ValueObjects.Players
{
    public class PlayerBetContext : ValueObject
    {
        public int? BBPlayerId { get; private set; }
        public int? MappingAgentId { get; private set; }
        public DateTime? MappedAt { get; private set; }

        private PlayerBetContext() { }
        
        internal PlayerBetContext(int? bBPlayerId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            BBPlayerId = bBPlayerId;
            MappingAgentId = mappingAgentId;
            MappedAt = mappedAt;
        }

        public static PlayerBetContext Create(int? bBPlayerId,
            int? mappingAgentId,
            DateTime? mappedAt)
        {
            return new PlayerBetContext(bBPlayerId: bBPlayerId,
                mappingAgentId: mappingAgentId,
                mappedAt: mappedAt);
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return BBPlayerId;
            yield return MappingAgentId;
        }
    }
}
