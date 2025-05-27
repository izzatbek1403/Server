using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities.Inventory;

namespace Server.Infrastructure.Data.Configurations
{
    public class GoodsGroupConfiguration : IEntityTypeConfiguration<GoodsGroup>
    {
        public void Configure(EntityTypeBuilder<GoodsGroup> builder)
        {
            builder.ToTable("GOODS_GROUPS"); // Firebird tablo adı

            // Primary Key - BaseEntity'den geliyor
            builder.HasKey(gg => gg.UID);

            builder.Property(gg => gg.UID)
                .HasMaxLength(36)
                .IsRequired(); // GUID primary key

            // BaseEntity Properties
            builder.Property(gg => gg.IS_DELETED)
                .HasDefaultValue(false); // Soft delete

            // Relationships - sadece mevcut property'ler varsa
            builder.HasMany(gg => gg.Goods)
                .WithOne(g => g.Group)
                .HasForeignKey(g => g.GROUP_UID)
                .OnDelete(DeleteBehavior.Restrict); // Group silinirse goods orphan kalır

            // Indexes
            builder.HasIndex(gg => gg.IS_DELETED); // Performance için
        }
    }
}