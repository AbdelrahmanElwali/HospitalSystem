using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Surgery;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class SurgerySupplyRepository : ISurgerySupplyRepository
    {
        private readonly ApplicationDbContext _context;

        public SurgerySupplyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SurgerySupply>> GetBySurgeryIdAsync(Guid surgeryId)
        {
            return await _context.SurgerySupplies
                .Where(ss => ss.SurgeryId == surgeryId)
                .ToListAsync();
        }

        public async Task AddAsync(SurgerySupply supply)
        {
            _context.SurgerySupplies.Add(supply);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var supply = await _context.SurgerySupplies.FindAsync(id);
            if (supply != null)
            {
                _context.SurgerySupplies.Remove(supply);
                await _context.SaveChangesAsync();
            }
        }
    }
}
