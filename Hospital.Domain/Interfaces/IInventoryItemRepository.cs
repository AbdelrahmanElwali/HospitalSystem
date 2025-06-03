using Hospital.Domain.Users.Inventory;

namespace Hospital.Domain.Interfaces
{
    public interface IInventoryItemRepository
    {
        Task<IEnumerable<InventoryItem>> GetAllAsync();
        Task<InventoryItem?> GetByIdAsync(int id);
        Task<InventoryItem> AddAsync(InventoryItem item);
        Task<InventoryItem> UpdateAsync(InventoryItem item);
        Task DeleteAsync(int id);
    }
}
