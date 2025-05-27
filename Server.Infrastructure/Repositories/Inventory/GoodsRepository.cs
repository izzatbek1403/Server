using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities.Inventory;
using Server.Domain.Repositories.Inventory;
using Server.Infrastructure.Data.Context;

namespace Server.Infrastructure.Repositories.Inventory
{
    internal class GoodsRepository : Repository<Good>, IGoodsRepository // internal - Infrastructure boundary
    {
        public GoodsRepository(ApplicationDbContext context) : base(context) // Internal context injection
        {
        }

        public async Task<IEnumerable<Good>> GetGoodsByGroupAsync(string groupUid)
        {
            return await _dbSet
                .Where(g => g.GROUP_UID == groupUid && !g.IS_DELETED) // Group filtering
                .Include(g => g.Group) // Eager loading - N+1 problem prevention
                .OrderBy(g => g.NAME) // Alphabetical sorting
                .ToListAsync();
        }

        public async Task<IEnumerable<Good>> SearchByNameAsync(string name)
        {
            return await _dbSet
                .Where(g => g.NAME.Contains(name) && !g.IS_DELETED) // Case-sensitive search
                .Include(g => g.Group)
                .OrderBy(g => g.NAME)
                .ToListAsync();
        }

        public async Task<Good?> GetByBarcodeAsync(string barcode)
        {
            return await _dbSet
                .Where(g => (g.BARCODE == barcode || g.BARCODES.Contains(barcode)) && !g.IS_DELETED) // Multiple barcode support
                .Include(g => g.Group)
                .FirstOrDefaultAsync(); // Single result expected
        }

        public async Task<IEnumerable<Good>> GetGoodsWithStockAsync()
        {
            return await _dbSet
                .Where(g => !g.IS_DELETED)
                .Include(g => g.Stocks.Where(s => !s.IS_DELETED && s.STOCK > 0)) // Only positive stock
                .Include(g => g.Group)
                .Where(g => g.Stocks.Any()) // Has stock records
                .ToListAsync();
        }

        public async Task<IEnumerable<Good>> GetLowStockGoodsAsync(decimal minStock = 0)
        {
            return await _dbSet
                .Where(g => !g.IS_DELETED)
                .Include(g => g.Stocks.Where(s => !s.IS_DELETED))
                .Include(g => g.Group)
                .Where(g => g.Stocks.Sum(s => s.STOCK) <= minStock) // Stock threshold check
                .OrderBy(g => g.Stocks.Sum(s => s.STOCK)) // Lowest stock first
                .ToListAsync();
        }
    }
}
