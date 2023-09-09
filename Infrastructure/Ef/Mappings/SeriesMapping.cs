using Series = SportsBet.Domain.Aggregates.Series.Series;

namespace SportsBet.Infrastructure.Ef.Mappings;

public class SeriesMapping : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.ToTable("Series");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.Info, c =>
        {
            c.Property(x => x.NumberOfMatches).HasColumnName("NumberOfMatches").IsRequired();

        });

        builder.OwnsOne(c => c.Team1, s =>
        {
            s.Property(x => x.TeamId).HasColumnName("Team1_TeamId").IsRequired();

            s.OwnsOne(st => st.Score, ss =>
            {
                ss.Property(x => x.Score).HasColumnName("Team1_Score").IsRequired(false);
                ss.Property(x => x.Standing).HasColumnName("Team1_Standing").IsRequired(false);
            });
        });
            
        builder.OwnsOne(c => c.Team2, s =>
        {
            s.Property(x => x.TeamId).HasColumnName("Team2_TeamId").IsRequired();

            s.OwnsOne(st => st.Score, ss =>
            {
                ss.Property(x => x.Score).HasColumnName("Team2_Score").IsRequired(false);
                ss.Property(x => x.Standing).HasColumnName("Team2_Standing").IsRequired(false);
            });
        });

        builder.Property(c => c.WinnerTeamId).IsRequired(false);

        builder
            .HasMany(c => c.SeriesMatches)
            .WithOne()
            .IsRequired()
            .HasForeignKey("SeriesId")
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