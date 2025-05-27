using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities.Inventory;

namespace Server.Infrastructure.Data.Configurations
{
    public class GoodsStockConfiguration : IEntityTypeConfiguration<GoodsStock>
    {
        public void Configure(EntityTypeBuilder<GoodsStock> builder)
        {
            builder.ToTable("GOODS_STOCK");
            builder.HasKey(gs => gs.UID);
            builder.Property(gs => gs.UID).HasMaxLength(36).IsRequired();
            builder.Property(gs => gs.IS_DELETED).HasDefaultValue(false);
            builder.HasIndex(gs => gs.IS_DELETED);
        }
    }
}