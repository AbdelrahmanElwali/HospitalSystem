using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Inpatients;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class BedRepository : IBedRepository
    {
        private readonly ApplicationDbContext _context;

        public BedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bed>> GetByRoomIdAsync(Guid roomId)
        {
            return await _context.Beds.Where(b => b.RoomId == roomId).ToListAsync();
        }

        public async Task<Bed?> GetByIdAsync(Guid id)
        {
            return await _context.Beds.FindAsync(id);
        }

        public async Task AddAsync(Bed bed)
        {
            _context.Beds.Add(bed);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bed bed)
        {
            _context.Beds.Update(bed);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var bed = await _context.Beds.FindAsync(id);
            if (bed != null)
            {
                _context.Beds.Remove(bed);
                await _context.SaveChangesAsync();
            }
        }
    }
}
