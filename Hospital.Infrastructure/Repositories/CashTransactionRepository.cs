using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Finance;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class CashTransactionRepository : ICashTransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public CashTransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CashTransaction>> GetAllAsync()
        {
            return await _context.CashTransactions.ToListAsync();
        }

        public async Task<CashTransaction?> GetByIdAsync(Guid id)
        {
            return await _context.CashTransactions.FindAsync(id);
        }

        public async Task AddAsync(CashTransaction transaction)
        {
            _context.CashTransactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var transaction = await _context.CashTransactions.FindAsync(id);
            if (transaction != null)
            {
                _context.CashTransactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
