using Server.Domain.Entities.Common;

namespace Server.Domain.Entities.Inventory
{
    public class Good : BaseEntity
    {
        public string NAME { get; set; } = string.Empty;
        public string BARCODE { get; set; } = string.Empty;
        public string BARCODES { get; set; } = string.Empty;
        public string DESCRIPTION { get; set; } = string.Empty;
        public DateTime DATE_ADD { get; set; } = DateTime.UtcNow;
        public string GROUP_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public int SET_STATUS { get; set; } = 0;
        public DateTime DATE_UPDATE { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual GoodsGroup? Group { get; set; }
        public virtual ICollection<GoodsStock> Stocks { get; set; } = new List<GoodsStock>();
        public virtual ICollection<GoodsModification> Modifications { get; set; } = new List<GoodsModification>();
    }
}
