using Hospital.Domain.Users.Prescriptions;

namespace Hospital.Domain.Interfaces
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllAsync();
        Task<Prescription?> GetByIdAsync(int id);
        Task<Prescription> AddAsync(Prescription prescription);
        Task<Prescription> UpdateAsync(Prescription prescription);
        Task DeleteAsync(int id);
    }
}
