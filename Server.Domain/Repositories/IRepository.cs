using Server.Domain.Entities.Common;

namespace Server.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(string uid);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetActiveAsync(); // IS_DELETED = false
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string uid); // Soft delete
        Task<bool> ExistsAsync(string uid);
        Task<int> CountAsync();
    }
}
