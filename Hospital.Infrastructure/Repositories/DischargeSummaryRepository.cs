using Hospital.Domain.Interfaces;
using Hospital.Domain.Users.Discharge;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class DischargeSummaryRepository : IDischargeSummaryRepository
    {
        private readonly ApplicationDbContext _context;

        public DischargeSummaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DischargeSummary>> GetAllAsync()
        {
            return await _context.DischargeSummaries.ToListAsync();
        }

        public async Task<DischargeSummary?> GetByIdAsync(int id)
        {
            return await _context.DischargeSummaries.FindAsync(id);
        }

        public async Task<DischargeSummary> AddAsync(DischargeSummary summary)
        {
            _context.DischargeSummaries.Add(summary);
            await _context.SaveChangesAsync();
            return summary;
        }

        public async Task<DischargeSummary> UpdateAsync(DischargeSummary summary)
        {
            _context.DischargeSummaries.Update(summary);
            await _context.SaveChangesAsync();
            return summary;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.DischargeSummaries.FindAsync(id);
            if (item != null)
            {
                _context.DischargeSummaries.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
