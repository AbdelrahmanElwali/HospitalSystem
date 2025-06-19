using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Inpatients;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class StaySupplyRepository : IStaySupplyRepository
    {
        private readonly ApplicationDbContext _context;

        public StaySupplyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StaySupply>> GetByStayIdAsync(Guid stayId)
        {
            return await _context.StaySupplies
                .Where(s => s.PatientStayId == stayId)
                .ToListAsync();
        }

        public async Task AddAsync(StaySupply supply)
        {
            _context.StaySupplies.Add(supply);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var supply = await _context.StaySupplies.FindAsync(id);
            if (supply != null)
            {
                _context.StaySupplies.Remove(supply);
                await _context.SaveChangesAsync();
            }
        }
    }
}
