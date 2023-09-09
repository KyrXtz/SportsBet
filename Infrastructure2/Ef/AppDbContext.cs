using Series = SportsBet.Domain.Aggregates.Series.Series;
using SeriesMatch = SportsBet.Domain.Aggregates.Series.SeriesMatch;

namespace SportsBet.Infrastructure.Ef;

public class AppDbContext : DbContext
{
    private readonly IMediatorHandler _mediatorHandler;
    public AppDbContext(DbContextOptions<AppDbContext> options, IMediatorHandler mediatorHandler)
        : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }

    public DbSet<Competitor> Competitors { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<SeriesMatch> SeriesMatches { get; set; }
    public DbSet<Sport> Sports { get; set; }
    public DbSet<SportsTicker> SportsTickers { get; set; }
    public DbSet<SportsTickerEvent> SportsTickerEvents { get; set; }
    public DbSet<SportsTickerLineup> SportsTickerLineups { get; set; }
    public DbSet<SportsTickerStat> SportsTickerStats { get; set; }
    public DbSet<ErroredCommandLog> ErroredCommandLogs { get; set; }
    //public DbSet<IntegrationEventOutboxItem> IntegrationEventOutboxItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

        ReadDateTimeAsUTC(modelBuilder);

        modelBuilder.ConfigureSmartEnum();
    }

    private void OnBeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();

        var modifiedEntries = ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity
                        && (x.State == EntityState.Added
                            || x.State == EntityState.Modified));

        foreach (var entry in modifiedEntries)
        {
            var entity = entry.Entity as BaseEntity;

            if (entity is null)
                continue;

            switch (entry.State)
            {
                case EntityState.Added:
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                        break;
                    }
                case EntityState.Modified:
                    {
                        entity.LastModifiedOn = DateTime.UtcNow;
                        break;
                    }
                default:
                    break;
            }
        }
    }

    private async Task OnAfterSaveChanges(CancellationToken cancellationToken = new())
    {
        if (_mediatorHandler == null) return;

        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.ClearDomainEvents();

            foreach (var domainEvent in events)
            {
                await _mediatorHandler.RaiseEvent(domainEvent, cancellationToken);
            }
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        OnBeforeSaveChanges();

        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        await OnAfterSaveChanges(cancellationToken);

        return result;
    }

    private static void ReadDateTimeAsUTC(ModelBuilder modelBuilder)
    {
        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    property.SetValueConverter(dateTimeConverter);
            }
        }
    }
}