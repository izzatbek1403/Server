using Server.Domain.Entities.Common;

namespace Server.Domain.Entities.Inventory
{
    public class GoodsStock : BaseEntity
    {
        public string GOOD_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string MODIFICATION_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string STORAGE_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public decimal STOCK { get; set; } = 0.0m;
        public decimal PRICE { get; set; } = 0.0m;

        // Navigation Properties
        public virtual Good? Good { get; set; }
        public virtual GoodsModification? Modification { get; set; }
        public virtual Storage? Storage { get; set; }
    }
}
