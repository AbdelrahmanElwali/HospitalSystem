using Hospital.Application.Interfaces;
using Hospital.Domain.Users.HumanResources;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class EmployeeAdjustmentRepository : IEmployeeAdjustmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeAdjustmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeAdjustment>> GetAllAsync()
        {
            return await _context.EmployeeAdjustments.ToListAsync();
        }

        public async Task<EmployeeAdjustment?> GetByIdAsync(Guid id)
        {
            return await _context.EmployeeAdjustments.FindAsync(id);
        }

        public async Task AddAsync(EmployeeAdjustment adjustment)
        {
            _context.EmployeeAdjustments.Add(adjustment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var adjustment = await _context.EmployeeAdjustments.FindAsync(id);
            if (adjustment != null)
            {
                _context.EmployeeAdjustments.Remove(adjustment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
