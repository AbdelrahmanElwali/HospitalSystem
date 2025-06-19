using Hospital.Domain.Users.HumanResources;

namespace Hospital.Application.Interfaces
{
    public interface IEmployeeSalaryRepository
    {
        Task<IEnumerable<EmployeeSalary>> GetAllAsync();
        Task<EmployeeSalary?> GetByIdAsync(Guid id);
        Task AddAsync(EmployeeSalary salary);
        Task UpdateAsync(EmployeeSalary salary);
        Task DeleteAsync(Guid id);
    }
}
