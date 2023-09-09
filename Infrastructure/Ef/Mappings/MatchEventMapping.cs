using Match = SportsBet.Domain.Aggregates.Matches.Match;

namespace SportsBet.Infrastructure.Ef.Mappings;

public class MatchEventMapping : IEntityTypeConfiguration<MatchEvent>
{
    public void Configure(EntityTypeBuilder<MatchEvent> builder)
    {
        builder.ToTable("MatchEvents");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.Info, c =>
        {
            c.Property(x => x.EventId).HasColumnName("EventId").IsRequired();
            c.Property(x => x.EventNumber).HasColumnName("EventNumber").IsRequired();
            c.Property(x => x.EventCode).HasColumnName("EventCode").HasMaxLength(100).IsRequired();
            c.Property(x => x.State)
                .HasColumnName("State")
                .HasConversion(x => x.Value, x => MatchState.FromValue(x))
                .IsRequired();
        });

        builder.OwnsOne(c => c.Time, c =>
        {
            c.Property(x => x.Minute).HasColumnName("Minute").IsRequired();
            c.Property(x => x.Timestamp).HasColumnName("Timestamp").IsRequired(false);
            c.Property(x => x.ClockRunning).HasColumnName("ClockRunning").IsRequired(false);
            c.Property(x => x.Date).HasColumnName("Date").IsRequired();
        });

        builder.OwnsOne(c => c.Reason, c =>
        {
            c.Property(x => x.Id).HasColumnName("ReasonId").IsRequired(false);
            c.Property(x => x.Value).HasColumnName("ReasonValue").HasMaxLength(100).IsRequired(false);
        });

        builder.Property(c => c.SpecialEvent)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<SpecialEventProperty>>(v));

        builder.HasOne<Match>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(e => e.MatchId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.Property(c => c.RelatedMatchEventNumbers)
            .HasConversion(
                list => list == null ? null : string.Join(";", list),
                str => string.IsNullOrWhiteSpace(str) ? null : str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()!
            );

        builder.Property(c => c.ClearedMatchEventNumbers)
            .HasConversion(
                list => list == null ? null : string.Join(";", list),
                str => string.IsNullOrWhiteSpace(str) ? null : str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()!
            );

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