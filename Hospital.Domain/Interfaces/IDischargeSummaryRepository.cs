using Hospital.Domain.Users.Discharge;

namespace Hospital.Domain.Interfaces
{
    public interface IDischargeSummaryRepository
    {
        Task<IEnumerable<DischargeSummary>> GetAllAsync();
        Task<DischargeSummary?> GetByIdAsync(int id);
        Task<DischargeSummary> AddAsync(DischargeSummary summary);
        Task<DischargeSummary> UpdateAsync(DischargeSummary summary);
        Task DeleteAsync(int id);
    }
}
