using Hospital.Domain.Users.Surgery;

namespace Hospital.Application.Interfaces
{
    public interface ISurgeryRepository
    {
        Task<IEnumerable<Surgery>> GetAllAsync();
        Task<Surgery?> GetByIdAsync(Guid id);
        Task AddAsync(Surgery surgery);
        Task UpdateAsync(Surgery surgery);
        Task DeleteAsync(Guid id);
    }
}
