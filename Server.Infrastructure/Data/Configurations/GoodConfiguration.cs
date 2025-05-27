using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain.Entities.Inventory;

namespace Server.Infrastructure.Data.Configurations
{
    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.ToTable("GOODS");

            builder.HasKey(g => g.UID);

            builder.Property(g => g.UID)
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(g => g.NAME)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(g => g.BARCODE)
                .HasMaxLength(1000);

            builder.Property(g => g.BARCODES)
                .HasMaxLength(1000);

            builder.Property(g => g.DESCRIPTION)
                .HasMaxLength(500);

            builder.Property(g => g.GROUP_UID)
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(g => g.DATE_ADD)
                .IsRequired();

            builder.Property(g => g.DATE_UPDATE)
                .IsRequired();

            builder.Property(g => g.IS_DELETED)
                .HasDefaultValue(false);

            builder.Property(g => g.SET_STATUS)
                .HasDefaultValue(0);

            // Relationships
            builder.HasOne(g => g.Group)
                .WithMany(gg => gg.Goods)
                .HasForeignKey(g => g.GROUP_UID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Stocks)
                .WithOne(s => s.Good)
                .HasForeignKey(s => s.GOOD_UID);

            builder.HasMany(g => g.Modifications)
                .WithOne(m => m.Good)
                .HasForeignKey(m => m.GOOD_UID);

            // Indexes
            builder.HasIndex(g => g.NAME);
            builder.HasIndex(g => g.BARCODE);
            builder.HasIndex(g => g.GROUP_UID);
            builder.HasIndex(g => g.IS_DELETED);
        }
    }
}
