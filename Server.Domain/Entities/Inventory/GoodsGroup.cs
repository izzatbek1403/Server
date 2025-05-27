using Server.Domain.Entities.Common;

namespace Server.Domain.Entities.Inventory
{
    public class GoodsGroup : BaseEntity
    {
        public string NAME { get; set; } = string.Empty;
        public string PARENT_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public int GOODS_TYPE { get; set; } = 0;
        public bool IS_DATA_PARENT { get; set; } = false;
        public bool IS_COMPOSITE_GOOD { get; set; } = false;
        public bool IS_REQUEST_COUNT { get; set; } = false;
        public string UNITS_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public int RU_TAX_SYSTEM { get; set; } = 0;
        public int RU_MARKED_PRODUCTION_TYPE { get; set; } = 0;
        public bool NEED_COMMENT { get; set; } = false;
        public int KKM_TAX_NUMBER { get; set; } = 1;
        public int KKM_SECTION_NUMBER { get; set; } = 1;
        public bool IS_FREE_PRICE { get; set; } = false;
        public int RU_FFD_GOODS_TYPE { get; set; } = 0;
        public int DECIMAL_PLACE { get; set; } = 0;

        // Navigation Properties
        public virtual GoodsGroup? Parent { get; set; }
        public virtual ICollection<GoodsGroup> Children { get; set; } = new List<GoodsGroup>();
        public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
        public virtual GoodsUnit? Unit { get; set; }
    }
}
