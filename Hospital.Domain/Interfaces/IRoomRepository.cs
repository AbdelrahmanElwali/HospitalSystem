using Hospital.Domain.Users.Inpatients;
using Hospital.Domain.Users.Rooms;

namespace Hospital.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(Guid id);
        Task AddAsync(Room room);
        Task UpdateAsync(Room room);
        Task DeleteAsync(Guid id);
    }
}
