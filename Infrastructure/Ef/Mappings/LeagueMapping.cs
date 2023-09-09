namespace SportsBet.Infrastructure.Ef.Mappings;

public class LeagueMapping : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)

    {
        builder.ToTable("Leagues");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.Name, c =>
        {
            c.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        });

        builder.OwnsOne(c => c.BetContext, c =>
        {
            c.Property(x => x.BBCompetitionId).HasColumnName("BBCompetitionId").IsRequired(false);
            c.Property(x => x.MappingAgentId).HasColumnName("MappingAgentId").IsRequired(false);
            c.Property(x => x.MappedAt).HasColumnName("MappedAt").IsRequired(false);
        });

        builder.OwnsOne(c => c.Parameters, c =>
        {
            c.Property(x => x.RegularPlaytime).HasColumnName("RegularPlaytime").IsRequired(false);
            c.Property(x => x.OverPlaytime).HasColumnName("OverPlaytime").IsRequired(false);
            c.Property(x => x.HasPenaltyShootout).HasColumnName("HasPenaltyShootout").IsRequired(false);
            c.Property(x => x.HasPlayerData).HasColumnName("HasPlayerData").IsRequired(false);
        });

        builder.Property(c => c.LeagueGameModeDetails)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<LeagueGameModeDetail>>(v));

        builder.HasOne<Sport>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.SportId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasOne<Country>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(p => p.CountryId)
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