using Hospital.Domain.Users.MedicalServices;

namespace Hospital.Application.Interfaces
{
    public interface IMedicalServiceRepository
    {
        Task<IEnumerable<MedicalService>> GetAllAsync();
        Task<MedicalService?> GetByIdAsync(Guid id);
        Task AddAsync(MedicalService service);
        Task UpdateAsync(MedicalService service);
        Task DeleteAsync(Guid id);
    }
}
