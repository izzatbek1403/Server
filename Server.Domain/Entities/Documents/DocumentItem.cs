using Server.Domain.Entities.Common;
using Server.Domain.Entities.Inventory;

namespace Server.Domain.Entities.Documents
{
    public class DocumentItem : BaseEntity
    {
        public string DOCUMENT_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string GOOD_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string MODIFICATION_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string STOCK_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public decimal QUANTITY { get; set; } = 0.0m;
        public decimal DISCOUNT { get; set; } = 0.0m;
        public decimal BUY_PRICE { get; set; } = 0.0m;
        public decimal SALE_PRICE { get; set; } = 0.0m;
        public string COMMENT { get; set; } = string.Empty;

        // Navigation Properties
        public virtual Document? Document { get; set; }
        public virtual Good? Good { get; set; }
        public virtual GoodsModification? Modification { get; set; }
        public virtual GoodsStock? Stock { get; set; }

        // Computed Properties
        public decimal TotalAmount => QUANTITY * SALE_PRICE * (1 - DISCOUNT / 100);
        public decimal NetPrice => SALE_PRICE * (1 - DISCOUNT / 100);
    }
}
