using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities.Inventory;

namespace Server.Infrastructure.Data.Configurations
{
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.ToTable("STORAGES");
            builder.HasKey(s => s.UID);
            builder.Property(s => s.UID).HasMaxLength(36).IsRequired();
            builder.Property(s => s.IS_DELETED).HasDefaultValue(false);
            builder.HasIndex(s => s.IS_DELETED);
        }
    }
}