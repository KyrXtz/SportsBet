namespace SportsBet.Infrastructure.Ef.Mappings;

public class CompetitorMapping : IEntityTypeConfiguration<Competitor>
{
    public void Configure(EntityTypeBuilder<Competitor> builder)
    {
        builder.ToTable("Competitors");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.CompetitorName, c =>
        {
            c.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        });

        builder.Property(c => c.IsIndividual).HasColumnName("IsIndividual").IsRequired();

        builder.OwnsOne(c => c.BetContext, c =>
        {
            c.Property(x => x.BBCompetitorId).HasColumnName("BBCompetitorId").IsRequired(false);
            c.Property(x => x.MappingAgentId).HasColumnName("MappingAgentId").IsRequired(false);
            c.Property(x => x.MappedAt).HasColumnName("MappedAt").IsRequired(false);
        });

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