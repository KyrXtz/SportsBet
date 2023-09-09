namespace SportsBet.Infrastructure.Configuration
{
    public static class UniqueIdGeneratorConfiguration
    {
        public static IServiceCollection ConfigUniqueIdGenerator(this IServiceCollection services)
        {
            var guid = Guid.NewGuid();
            var bytes = guid.ToByteArray();
            var num = BitConverter.ToInt32(bytes);
            var seed = Math.Abs(num) % 1023;

            UniqueIdGenerator.Configure(seed);

            return services;
        }
    }
}