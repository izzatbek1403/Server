using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities.Inventory;

namespace Server.Infrastructure.Data.Configurations
{
    public class GoodsModificationConfiguration : IEntityTypeConfiguration<GoodsModification>
    {
        public void Configure(EntityTypeBuilder<GoodsModification> builder)
        {
            builder.ToTable("GOODS_MODIFICATIONS");
            builder.HasKey(gm => gm.UID);
            builder.Property(gm => gm.UID).HasMaxLength(36).IsRequired();
            builder.Property(gm => gm.IS_DELETED).HasDefaultValue(false);
            builder.HasIndex(gm => gm.IS_DELETED);
        }
    }
}