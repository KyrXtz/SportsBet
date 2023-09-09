namespace SportsBet.Infrastructure.Ef.Mappings;

public class SquadMapping : IEntityTypeConfiguration<Squad>
{
    public void Configure(EntityTypeBuilder<Squad> builder)
    {
        builder.ToTable("Squads");

        builder.HasKey(c => c.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.Info, c =>
        {
            c.Property(x => x.JerseyNumber).HasColumnName("JerseyNumber").IsRequired(false);
            c.Property(x => x.Rating).HasColumnName("Rating").HasConversion(p => p.Value, p => PlayerRating.FromValue(p)).IsRequired();
        });

        builder.HasOne<Competitor>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.CompetitorId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasOne<Player>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.PlayerId)
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