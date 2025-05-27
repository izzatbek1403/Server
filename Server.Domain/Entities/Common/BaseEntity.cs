namespace Server.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public string UID { get; set; } = Guid.CreateVersion7().ToString(); // Time-ordered GUID - performans ve sıralama için optimal
        public bool IS_DELETED { get; set; } = false; // Soft delete flag - veri kaybını önler
    }
}