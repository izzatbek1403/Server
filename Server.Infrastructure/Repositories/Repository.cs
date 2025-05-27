using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities.Common;
using Server.Domain.Repositories;
using Server.Infrastructure.Data.Context;

namespace Server.Infrastructure.Repositories
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity // internal - Infrastructure içinde kapsüllenmiş
    {
        protected readonly ApplicationDbContext _context; // Internal context'e erişim
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context) // Constructor injection - internal context
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(string uid)
        {
            return await _dbSet.FindAsync(uid); // Primary key ile bulma
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync(); // Soft delete filter otomatik uygulanır
        }

        public virtual async Task<IEnumerable<T>> GetActiveAsync()
        {
            return await _dbSet.Where(x => !x.IS_DELETED).ToListAsync(); // Explicit active filter
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            if (string.IsNullOrEmpty(entity.UID))
            {
                entity.UID = Guid.CreateVersion7().ToString(); // Time-ordered GUID generation
            }

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync(); // Audit trail otomatik çalışır
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity); // Change tracking ile güncelleme
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(string uid)
        {
            var entity = await GetByIdAsync(uid);
            if (entity != null)
            {
                entity.IS_DELETED = true; // Soft delete - fiziksel silme yapmaz
                await UpdateAsync(entity);
            }
        }

        public virtual async Task<bool> ExistsAsync(string uid)
        {
            return await _dbSet.AnyAsync(x => x.UID == uid && !x.IS_DELETED); // Existence check
        }

        public virtual async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync(x => !x.IS_DELETED); // Active record count
        }
    }
}
