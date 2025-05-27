using System.ComponentModel.DataAnnotations;

namespace Server.Application.Common.DTOs.Inventory
{
    public class CreateGoodDto
    {
        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(200, ErrorMessage = "Ürün adı maksimum 200 karakter olabilir")]
        public string Name { get; set; } = string.Empty; // Ürün adı (zorunlu)

        [StringLength(1000, ErrorMessage = "Barkod maksimum 1000 karakter olabilir")]
        public string? Barcode { get; set; } // Ana barkod (opsiyonel)

        [StringLength(1000, ErrorMessage = "Ek barkodlar maksimum 1000 karakter olabilir")]
        public string? Barcodes { get; set; } // Ek barkodlar (opsiyonel)

        [StringLength(500, ErrorMessage = "Açıklama maksimum 500 karakter olabilir")]
        public string? Description { get; set; } // Ürün açıklaması (opsiyonel)

        [Required(ErrorMessage = "Ürün grubu seçimi zorunludur")]
        public string GroupUID { get; set; } = string.Empty; // Ürün grubu (zorunlu)

        [Range(0, 2, ErrorMessage = "Durum değeri 0-2 arasında olmalıdır")]
        public int SetStatus { get; set; } = 0; // Ürün durumu (varsayılan: pasif)
    }
}
