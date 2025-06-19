using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Surgery;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class SurgeryStaffRepository : ISurgeryStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public SurgeryStaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SurgeryStaff>> GetBySurgeryIdAsync(Guid surgeryId)
        {
            return await _context.SurgeryStaffs
                .Where(ss => ss.SurgeryId == surgeryId)
                .ToListAsync();
        }

        public async Task AddAsync(SurgeryStaff staff)
        {
            _context.SurgeryStaffs.Add(staff);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var staff = await _context.SurgeryStaffs.FindAsync(id);
            if (staff != null)
            {
                _context.SurgeryStaffs.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }
    }
}
