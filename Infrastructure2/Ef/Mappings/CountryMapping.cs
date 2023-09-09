namespace SportsBet.Infrastructure.Ef.Mappings;

public class CountryMapping : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.Property(c => c.ProviderId).HasColumnName("ProviderId").IsRequired();

        builder.OwnsOne(c => c.Name, c =>
        {
            c.Property(x => x.ISOCode).HasColumnName("ISOCode").HasMaxLength(100).IsRequired(false);
            c.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

        });
            
        builder.OwnsOne(p => p.BetContext, p =>
        {
            p.Property(x => x.BBRegionId).HasColumnName("BBRegionId").IsRequired(false);
            p.Property(x => x.MappingAgentId).HasColumnName("MappingAgentId").IsRequired(false);
            p.Property(x => x.MappedAt).HasColumnName("MappedAt").IsRequired(false);
        });

        builder.HasOne<Sport>()
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(p => p.SportId)
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