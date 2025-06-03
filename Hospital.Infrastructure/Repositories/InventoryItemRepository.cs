using Hospital.Domain.Interfaces;
using Hospital.Domain.Users.Inventory;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryItem>> GetAllAsync()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        public async Task<InventoryItem?> GetByIdAsync(int id)
        {
            return await _context.InventoryItems.FindAsync(id);
        }

        public async Task<InventoryItem> AddAsync(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<InventoryItem> UpdateAsync(InventoryItem item)
        {
            _context.InventoryItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item != null)
            {
                _context.InventoryItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
