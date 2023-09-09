using Series = SportsBet.Domain.Aggregates.Series.Series;
using SeriesMatch = SportsBet.Domain.Aggregates.Series.SeriesMatch;

namespace SportsBet.Infrastructure.Ef.Mappings;

public class SeriesMatchMapping : IEntityTypeConfiguration<SeriesMatch>
{
    public void Configure(EntityTypeBuilder<SeriesMatch> builder)
    {
        builder.ToTable("SeriesMatches");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.Property(c => c.SportsTickerId).HasColumnName("SportsTickerId");

        builder.HasOne<Series>()
            .WithMany(s => s.SeriesMatches)
            .IsRequired()
            .HasForeignKey("SeriesId")
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.OwnsOne(c => c.Score1, c =>
        {
            c.Property(x => x.Score).HasColumnName("Score1").HasMaxLength(100).IsRequired(false);
            c.Property(x => x.Standing).HasColumnName("Standing1").HasMaxLength(100).IsRequired(false);

        });

        builder.OwnsOne(c => c.Score2, c =>
        {
            c.Property(x => x.Score).HasColumnName("Score2").HasMaxLength(100).IsRequired(false);
            c.Property(x => x.Standing).HasColumnName("Standing2").HasMaxLength(100).IsRequired(false);

        });

        builder.Property(c => c.Leg).IsRequired();

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