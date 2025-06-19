using Hospital.Domain.Users.Finance;

namespace Hospital.Application.Interfaces
{
    public interface ICashTransactionRepository
    {
        Task<IEnumerable<CashTransaction>> GetAllAsync();
        Task<CashTransaction?> GetByIdAsync(Guid id);
        Task AddAsync(CashTransaction transaction);
        Task DeleteAsync(Guid id);
    }
}
