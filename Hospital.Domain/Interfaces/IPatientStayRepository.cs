using Hospital.Domain.Users.Inpatients;

namespace Hospital.Application.Interfaces
{
    public interface IPatientStayRepository
    {
        Task<IEnumerable<PatientStay>> GetAllAsync();
        Task<PatientStay?> GetByIdAsync(Guid id);
        Task AddAsync(PatientStay stay);
        Task UpdateAsync(PatientStay stay);
        Task DeleteAsync(Guid id);
    }
}
