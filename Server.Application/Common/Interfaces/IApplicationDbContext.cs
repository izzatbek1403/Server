using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities.Documents;
using Server.Domain.Entities.Inventory;

namespace Server.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        // Inventory DbSets
        DbSet<Good> GOODS { get; set; } // Ürünler tablosu
        DbSet<GoodsGroup> GOODS_GROUPS { get; set; } // Ürün grupları tablosu
        DbSet<GoodsStock> GOODS_STOCK { get; set; } // Stok durumu tablosu
        DbSet<GoodsModification> GOODS_MODIFICATIONS { get; set; } // Ürün varyasyonları
        DbSet<GoodsUnit> GOODS_UNITS { get; set; } // Ölçü birimleri
        DbSet<Storage> STORAGES { get; set; } // Depolar

        // Document DbSets  
        DbSet<Document> DOCUMENTS { get; set; } // Belgeler (satış, satın alma vb.)
        DbSet<DocumentItem> DOCUMENT_ITEMS { get; set; } // Belge kalemleri

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); // Değişiklikleri kaydet
    }
}
