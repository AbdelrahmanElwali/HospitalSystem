using Hospital.Domain.Users.Finance;

namespace Hospital.Application.Interfaces
{
    public interface IPatientAccountRepository
    {
        Task<IEnumerable<PatientAccount>> GetAllAsync();
        Task<PatientAccount?> GetByIdAsync(Guid id);
        Task AddAsync(PatientAccount account);
        Task UpdateAsync(PatientAccount account);
        Task DeleteAsync(Guid id);
    }
}
