using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities.Inventory;

namespace Server.Infrastructure.Data.Configurations
{
    public class GoodsUnitConfiguration : IEntityTypeConfiguration<GoodsUnit>
    {
        public void Configure(EntityTypeBuilder<GoodsUnit> builder)
        {
            builder.ToTable("GOODS_UNITS");
            builder.HasKey(gu => gu.UID);
            builder.Property(gu => gu.UID).HasMaxLength(36).IsRequired();
            builder.Property(gu => gu.IS_DELETED).HasDefaultValue(false);
            builder.HasIndex(gu => gu.IS_DELETED);
        }
    }
}