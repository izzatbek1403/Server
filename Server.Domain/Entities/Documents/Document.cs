using Server.Domain.Entities.Common;
using Server.Domain.Enums;

namespace Server.Domain.Entities.Documents
{
    public class Document : BaseEntity
    {
        public string PARENT_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string STORAGE_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string SECTION_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public DateTime DATE_TIME { get; set; } = DateTime.UtcNow;
        public string NUMBER { get; set; } = string.Empty;
        public string COMMENT { get; set; } = string.Empty;
        public DocumentType TYPE { get; set; } = DocumentType.None;
        public DocumentStatus STATUS { get; set; } = DocumentStatus.None;
        public string USER_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public string CONTRACTOR_UID { get; set; } = "00000000-0000-0000-0000-000000000000";
        public bool IS_FISCAL { get; set; } = false;

        // Navigation Properties
        public virtual Document? Parent { get; set; }
        public virtual ICollection<Document> Children { get; set; } = new List<Document>();
        public virtual ICollection<DocumentItem> Items { get; set; } = new List<DocumentItem>();

        // E-Ticaret için computed property
        public bool IsECommerceOrder => TYPE == DocumentType.ClientOrder;
        public bool IsSaleDocument => TYPE == DocumentType.Sale || TYPE == DocumentType.ClientOrder;
    }
}
