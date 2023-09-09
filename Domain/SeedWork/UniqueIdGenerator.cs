namespace SportsBet.Domain.SeedWork
{
    public static class UniqueIdGenerator
    {
        private static IdGenerator _generator;
        private static string alreadyConfigured = "Already configured";
        private static string idGeneratorNotInitialized = "UniqueIdGenerator is not initialized. Consider using Configure() first!";

        /// <summary>
        /// generatorId Must be 0 - 1023
        /// </summary>
        /// <param name="generatorId">Must be 0 - 1023</param>
        public static void Configure(int generatorId)
        {
            if (_generator != null)
                throw new InvalidOperationException(alreadyConfigured);

            _generator = new IdGenerator(generatorId);
        }

        public static long CreateId() => _generator?.CreateId() ?? throw new InvalidOperationException(idGeneratorNotInitialized);
    }
}
