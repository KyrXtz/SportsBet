namespace Infrastructure.Tests.EF
{
    [Collection("UniqueId Generator")]
    public abstract class RepositoryTests : IClassFixture<UniqueIdGeneratorDefinition>
    {
        protected readonly AppDbContext _dbContext;
        protected readonly Mock<IMediatorHandler> _mediatorHandler;
        public RepositoryTests(UniqueIdGeneratorDefinition uniqueIdGeneratorDefinition)
        {
            _mediatorHandler = new Mock<IMediatorHandler>();

            var dbName = $"SportsBetDb_{DateTime.Now.ToFileTimeUtc()}";
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            _dbContext = new AppDbContext(dbContextOptions, _mediatorHandler.Object);
        }
    }
}
