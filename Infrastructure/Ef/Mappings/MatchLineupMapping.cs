using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace SportsBet.Infrastructure.Ef.Mappings;

public class MatchLineupMapping : IEntityTypeConfiguration<MatchLineup>
{
    public void Configure(EntityTypeBuilder<MatchLineup> builder)
    {
        builder.ToTable("MatchLineups");

        builder.HasKey(c => c.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();

        builder.Property(c => c.Type)
            .HasColumnName("Type")
            .HasConversion(p => p.Value, p => MatchLineupType.FromValue(p))
            .IsRequired();

        builder.HasDiscriminator<string>("LineupType")
            .HasValue<MatchLineupHome>("Home")
            .HasValue<MatchLineupAway>("Away");

        builder.HasOne<Match>()
            .WithMany()
            .IsRequired()
            .HasForeignKey("MatchId")
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