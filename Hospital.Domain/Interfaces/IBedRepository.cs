using Hospital.Domain.Users.Inpatients;
using Hospital.Domain.Users.Rooms;

namespace Hospital.Application.Interfaces
{
    public interface IBedRepository
    {
        Task<IEnumerable<Bed>> GetByRoomIdAsync(Guid roomId);
        Task<Bed?> GetByIdAsync(Guid id);
        Task AddAsync(Bed bed);
        Task UpdateAsync(Bed bed);
        Task DeleteAsync(Guid id);
    }
}
