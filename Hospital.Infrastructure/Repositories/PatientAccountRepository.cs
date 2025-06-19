using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Finance;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class PatientAccountRepository : IPatientAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientAccount>> GetAllAsync()
        {
            return await _context.PatientAccounts.ToListAsync();
        }

        public async Task<PatientAccount?> GetByIdAsync(Guid id)
        {
            return await _context.PatientAccounts.FindAsync(id);
        }

        public async Task AddAsync(PatientAccount account)
        {
            _context.PatientAccounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PatientAccount account)
        {
            _context.PatientAccounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var account = await _context.PatientAccounts.FindAsync(id);
            if (account != null)
            {
                _context.PatientAccounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
