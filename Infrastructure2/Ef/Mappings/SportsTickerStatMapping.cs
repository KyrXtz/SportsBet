namespace SportsBet.Infrastructure.Ef.Mappings;

public class SportsTickerStatMapping : IEntityTypeConfiguration<SportsTickerStat>
{
    public void Configure(EntityTypeBuilder<SportsTickerStat> builder)
    {
        builder.ToTable("SportsTickerStats");

        builder.HasKey(c => c.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.Stat, c =>
        {
            c.Property(x => x.EventId).HasColumnName("EventId").IsRequired();
            c.Property(x => x.Value).HasColumnName("Value").HasMaxLength(100).IsRequired();
        });

        builder.HasOne<Player>()
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(p => p.PlayerId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasOne<Competitor>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.CompetitorId)
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