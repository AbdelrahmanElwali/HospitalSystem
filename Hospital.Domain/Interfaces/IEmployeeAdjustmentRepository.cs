using Hospital.Domain.Users.HumanResources;

namespace Hospital.Application.Interfaces
{
    public interface IEmployeeAdjustmentRepository
    {
        Task<IEnumerable<EmployeeAdjustment>> GetAllAsync();
        Task<EmployeeAdjustment?> GetByIdAsync(Guid id);
        Task AddAsync(EmployeeAdjustment adjustment);
        Task DeleteAsync(Guid id);
    }
}
