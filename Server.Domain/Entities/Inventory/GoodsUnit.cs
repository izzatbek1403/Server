using Server.Domain.Entities.Common;

namespace Server.Domain.Entities.Inventory
{
    public class GoodsUnit : BaseEntity
    {
        public string FULL_NAME { get; set; } = string.Empty;
        public string SHORT_NAME { get; set; } = string.Empty;
        public string CODE { get; set; } = string.Empty;
        public int RU_FFD_UNITS_INDEX { get; set; } = 0;

        // Navigation Properties
        public virtual ICollection<GoodsGroup> Groups { get; set; } = new List<GoodsGroup>();
    }
}
