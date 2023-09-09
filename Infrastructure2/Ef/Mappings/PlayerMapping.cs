namespace SportsBet.Infrastructure.Ef.Mappings;

public class PlayerMapping : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {

        builder.ToTable("Players");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.OwnsOne(c => c.Name, c =>
        {
            c.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
        });

        builder.Property(c => c.Position)
            .HasColumnName("Position")
            .HasConversion(p => p.Value, p => PlayerPosition.FromValue(p))
            .IsRequired();

        builder.Property(c => c.ProviderCountryId).HasColumnName("ProviderCountryId").IsRequired();

        builder.OwnsOne(c => c.BetContext, c =>
        {
            c.Property(x => x.BBPlayerId).HasColumnName("BBPlayerId").IsRequired(false);
            c.Property(x => x.MappingAgentId).HasColumnName("MappingAgentId").IsRequired(false);
            c.Property(x => x.MappedAt).HasColumnName("MappedAt").IsRequired(false);
        });

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