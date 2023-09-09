namespace SportsBet.Infrastructure.Ef.Mappings;

internal class ErroredCommandLogMapping : IEntityTypeConfiguration<ErroredCommandLog>
{
    public void Configure(EntityTypeBuilder<ErroredCommandLog> builder)
    {
        builder.ToTable("ErroredCommandLogs");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(p => p.ExceptionIdentity, p =>
        {
            p.Property(x => x.CommandName).HasColumnName("CommandName").HasColumnType("varchar(255)").IsRequired();
        });

        builder.OwnsOne(p => p.ExceptionData, p =>
        {
            p.Property(x => x.Data).HasColumnName("Data").IsRequired();
            p.Property(x => x.Message).HasColumnName("Message").IsRequired();
        });

        builder.Property(p => p.CreatedOn)
            .HasColumnName("CreatedAt")
            .IsRequired();

        builder.Property(p => p.LastModifiedOn)
            .HasColumnName("UpdatedAt")
            .IsRequired(false);

        builder.Property(p => p.RowVersion)
            .IsRequired()
            .HasColumnName("RowVersion")
            .IsRowVersion()
            .IsConcurrencyToken();

        builder.Ignore(x => x.Events);
    }
}