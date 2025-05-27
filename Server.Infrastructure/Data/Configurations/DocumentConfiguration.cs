using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities.Documents;

namespace Server.Infrastructure.Data.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("DOCUMENTS"); // Firebird tablo adı

            // Primary Key - BaseEntity'den geliyor
            builder.HasKey(d => d.UID); // UID primary key olarak tanımla

            builder.Property(d => d.UID)
                .HasMaxLength(36)
                .IsRequired(); // GUID string format

            // BaseEntity Properties
            builder.Property(d => d.IS_DELETED)
                .HasDefaultValue(false); // Soft delete flag

            // Index for soft delete
            builder.HasIndex(d => d.IS_DELETED); // Query performance için
        }
    }
}