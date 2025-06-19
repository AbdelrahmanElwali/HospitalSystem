using Hospital.Application.Interfaces;
using Hospital.Domain.Users.HumanResources;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class EmployeeLoanRepository : IEmployeeLoanRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeLoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeLoan>> GetAllAsync()
        {
            return await _context.EmployeeLoans.ToListAsync();
        }

        public async Task<EmployeeLoan?> GetByIdAsync(Guid id)
        {
            return await _context.EmployeeLoans.FindAsync(id);
        }

        public async Task AddAsync(EmployeeLoan loan)
        {
            _context.EmployeeLoans.Add(loan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var loan = await _context.EmployeeLoans.FindAsync(id);
            if (loan != null)
            {
                _context.EmployeeLoans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
