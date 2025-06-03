using Hospital.Domain.Users.Doctors;

namespace Hospital.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task<Doctor> AddAsync(Doctor doctor);
        Task<Doctor> UpdateAsync(Doctor doctor);
        Task DeleteAsync(int id);
    }
}
