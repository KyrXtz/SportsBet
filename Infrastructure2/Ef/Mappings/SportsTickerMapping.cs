namespace SportsBet.Infrastructure.Ef.Mappings;

public class SportsTickerMapping : IEntityTypeConfiguration<SportsTicker>
{
    public void Configure(EntityTypeBuilder<SportsTicker> builder)
    {
        builder.ToTable("SportsTickers");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.Name, c =>
        {
            c.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        });

        builder.OwnsOne(c => c.BetContext, c =>
        {
            c.Property(x => x.BBEventHistoryId).HasColumnName("BBEventHistoryId").IsRequired(false);
            c.Property(x => x.MappingAgentId).HasColumnName("MappingAgentId").IsRequired(false);
            c.Property(x => x.MappedAt).HasColumnName("MappedAt").IsRequired(false);
        });

        builder.Property(c => c.Status)
            .HasColumnName("Status")
            .HasConversion(p => p.Value, p => SportsTickerStatus.FromValue(p))
            .IsRequired();

        builder.OwnsOne(c => c.Date, c =>
        {
            c.Property(x => x.GameStart).HasColumnName("GameStart").IsRequired();
        });

        builder.OwnsOne(c => c.Parameters, c =>
        {

        });

        builder.OwnsOne(c => c.Competitors, c =>
        {
            c.Property(x => x.HomeCompetitorId).HasColumnName("HomeCompetitorId").IsRequired();
            c.Property(x => x.AwayCompetitorId).HasColumnName("AwayCompetitorId").IsRequired();
        });
            
        builder.OwnsOne(c => c.Score, c =>
        {
            c.Property(x => x.ScoreHome).HasColumnName("ScoreHome").IsRequired();
            c.Property(x => x.ScoreAway).HasColumnName("ScoreAway").IsRequired();
        });

        builder.Property(c => c.SpecialScore)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<SportsTickerSpecialScore>>(v));

        builder.Property(c => c.Details)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<SportsTickerDetail>>(v));

        builder
            .HasMany(c => c.HomeLineup)
            .WithOne()
            .IsRequired()
            .HasForeignKey("SportsTickerId")
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder
            .HasMany(c => c.AwayLineup)
            .WithOne()
            .IsRequired()
            .HasForeignKey("SportsTickerId")
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder
            .HasMany(c => c.Stats)
            .WithOne()
            .IsRequired()
            .HasForeignKey("SportsTickerId")
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder
            .HasMany(c => c.SportsTickerEvents)
            .WithOne()
            .IsRequired()
            .HasForeignKey("SportsTickerId")
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasOne<Sport>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.SportId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasOne<League>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.LeagueId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.Property(c => c.CreatedOn)
            .HasColumnName("CreatedAt")
            .IsRequired();

        builder.Property(c => c.LastModifiedOn)
            .HasColumnName("UpdatedAt")
            .IsRequired(false);

        builder.Property(c => c.RowVersion)
            .IsRequired()
            .HasColumnName("RowVersion")
            .IsRowVersion()
            .IsConcurrencyToken();

        builder.Ignore(c => c.Events);

    }
}