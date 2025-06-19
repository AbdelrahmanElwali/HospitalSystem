using Hospital.Domain.Users.HumanResources;

namespace Hospital.Application.Interfaces
{
    public interface IEmployeeLoanRepository
    {
        Task<IEnumerable<EmployeeLoan>> GetAllAsync();
        Task<EmployeeLoan?> GetByIdAsync(Guid id);
        Task AddAsync(EmployeeLoan loan);
        Task DeleteAsync(Guid id);
    }
}
