namespace Server.Application.Common.DTOs.Inventory
{
    public class GoodDto
    {
        public string UID { get; set; } = string.Empty; // Ürün benzersiz ID'si
        public string Name { get; set; } = string.Empty; // Ürün adı
        public string? Barcode { get; set; } // Ana barkod
        public string? Barcodes { get; set; } // Ek barkodlar (virgülle ayrılmış)
        public string? Description { get; set; } // Ürün açıklaması
        public string GroupUID { get; set; } = string.Empty; // Bağlı olduğu grup ID'si
        public string? GroupName { get; set; } // Grup adı (readonly - join'den gelir)
        public int SetStatus { get; set; } = 0; // Ürün durumu (0: pasif, 1: aktif)
        public DateTime DateAdd { get; set; } // Oluşturulma tarihi
        public DateTime DateUpdate { get; set; } // Son güncelleme tarihi
        public bool IsDeleted { get; set; } = false; // Silinme durumu

        // Computed Properties
        public bool IsActive => SetStatus == 1 && !IsDeleted; // Aktif ürün kontrolü
        public string DisplayName => string.IsNullOrEmpty(Barcode) ? Name : $"{Name} ({Barcode})"; // Görüntüleme adı
    }
}
