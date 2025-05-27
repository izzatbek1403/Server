using Server.Domain.Entities.Common;

namespace Server.Domain.Entities.Inventory
{
    public class GoodsModification : BaseEntity
    {
        public string GOOD_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string NAME { get; set; } = string.Empty;
        public string BARCODE { get; set; } = string.Empty;
        public string COMMENT { get; set; } = string.Empty;

        // Navigation Properties
        public virtual Good? Good { get; set; }
        public virtual ICollection<GoodsStock> Stocks { get; set; } = new List<GoodsStock>();
    }
}
