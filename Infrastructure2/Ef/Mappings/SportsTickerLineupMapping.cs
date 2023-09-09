namespace SportsBet.Infrastructure.Ef.Mappings;

public class SportsTickerLineupMapping : IEntityTypeConfiguration<SportsTickerLineup>
{
    public void Configure(EntityTypeBuilder<SportsTickerLineup> builder)
    {
        builder.ToTable("SportsTickerLineups");

        builder.HasKey(c => c.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();

        builder.Property(c => c.Type)
            .HasColumnName("Type")
            .HasConversion(p => p.Value, p => SportsTickerLineupType.FromValue(p))
            .IsRequired();

        builder.HasDiscriminator<string>("LineupType")
            .HasValue<SportsTickerLineupHome>("Home")
            .HasValue<SportsTickerLineupAway>("Away");

        builder.HasOne<SportsTicker>()
            .WithMany()
            .IsRequired()
            .HasForeignKey("SportsTickerId")
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.Property(p => p.CompetitorId)
            .HasColumnName("CompetitorId");

        builder.Property(p => p.PlayerId)
            .HasColumnName("PlayerId")
            .IsRequired(false);

        builder.Property(p => p.SportId)
            .HasColumnName("SportId");

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