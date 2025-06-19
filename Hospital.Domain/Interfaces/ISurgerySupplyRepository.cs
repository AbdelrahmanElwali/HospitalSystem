using Hospital.Domain.Users.Surgery;

namespace Hospital.Application.Interfaces
{
    public interface ISurgerySupplyRepository
    {
        Task<IEnumerable<SurgerySupply>> GetBySurgeryIdAsync(Guid surgeryId);
        Task AddAsync(SurgerySupply supply);
        Task DeleteAsync(Guid id);
    }
}
