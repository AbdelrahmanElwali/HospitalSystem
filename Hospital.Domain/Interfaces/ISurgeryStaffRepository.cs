using Hospital.Domain.Users.Surgery;

namespace Hospital.Application.Interfaces
{
    public interface ISurgeryStaffRepository
    {
        Task<IEnumerable<SurgeryStaff>> GetBySurgeryIdAsync(Guid surgeryId);
        Task AddAsync(SurgeryStaff staff);
        Task DeleteAsync(Guid id);
    }
}
