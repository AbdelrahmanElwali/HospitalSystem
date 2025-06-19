using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Surgery;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class SurgeryRepository : ISurgeryRepository
    {
        private readonly ApplicationDbContext _context;

        public SurgeryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Surgery>> GetAllAsync()
        {
            return await _context.Surgeries
                .Include(s => s.Staff)
                .Include(s => s.Supplies)
                .ToListAsync();
        }

        public async Task<Surgery?> GetByIdAsync(Guid id)
        {
            return await _context.Surgeries
                .Include(s => s.Staff)
                .Include(s => s.Supplies)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Surgery surgery)
        {
            _context.Surgeries.Add(surgery);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Surgery surgery)
        {
            _context.Surgeries.Update(surgery);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var surgery = await _context.Surgeries.FindAsync(id);
            if (surgery != null)
            {
                _context.Surgeries.Remove(surgery);
                await _context.SaveChangesAsync();
            }
        }
    }
}
