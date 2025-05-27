using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities.Documents;

namespace Server.Infrastructure.Data.Configurations
{
    public class DocumentItemConfiguration : IEntityTypeConfiguration<DocumentItem>
    {
        public void Configure(EntityTypeBuilder<DocumentItem> builder)
        {
            builder.ToTable("DOCUMENT_ITEMS"); // Firebird tablo adı

            // Primary Key - BaseEntity'den geliyor
            builder.HasKey(di => di.UID); // UID primary key

            builder.Property(di => di.UID)
                .HasMaxLength(36)
                .IsRequired(); // GUID string

            // BaseEntity Properties
            builder.Property(di => di.IS_DELETED)
                .HasDefaultValue(false); // Soft delete

            // Index for performance
            builder.HasIndex(di => di.IS_DELETED); // Soft delete filter için
        }
    }
}