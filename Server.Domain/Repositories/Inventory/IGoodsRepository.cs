using Server.Domain.Entities.Inventory;

namespace Server.Domain.Repositories.Inventory
{
    public interface IGoodsRepository : IRepository<Good>
    {
        Task<IEnumerable<Good>> GetGoodsByGroupAsync(string groupUid);
        Task<IEnumerable<Good>> SearchByNameAsync(string name);
        Task<Good?> GetByBarcodeAsync(string barcode);
        Task<IEnumerable<Good>> GetGoodsWithStockAsync();
        Task<IEnumerable<Good>> GetLowStockGoodsAsync(decimal minStock = 0);
    }
}
