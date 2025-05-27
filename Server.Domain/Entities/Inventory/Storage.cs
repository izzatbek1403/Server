using Server.Domain.Entities.Common;
using Server.Domain.Entities.Documents;

namespace Server.Domain.Entities.Inventory
{
    public class Storage : BaseEntity
    {
        public string NAME { get; set; } = string.Empty;

        // Navigation Properties
        public virtual ICollection<GoodsStock> Stocks { get; set; } = new List<GoodsStock>();
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
