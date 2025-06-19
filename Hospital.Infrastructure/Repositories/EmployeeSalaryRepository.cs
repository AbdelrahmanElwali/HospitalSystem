using Hospital.Application.Interfaces;
using Hospital.Domain.Users.HumanResources;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class EmployeeSalaryRepository : IEmployeeSalaryRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSalaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeSalary>> GetAllAsync()
        {
            return await _context.EmployeeSalaries.ToListAsync();
        }

        public async Task<EmployeeSalary?> GetByIdAsync(Guid id)
        {
            return await _context.EmployeeSalaries.FindAsync(id);
        }

        public async Task AddAsync(EmployeeSalary salary)
        {
            _context.EmployeeSalaries.Add(salary);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeSalary salary)
        {
            _context.EmployeeSalaries.Update(salary);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.EmployeeSalaries.FindAsync(id);
            if (item != null)
            {
                _context.EmployeeSalaries.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
