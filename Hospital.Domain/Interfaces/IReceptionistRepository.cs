using Hospital.Domain.Users.Receptionists;

namespace Hospital.Domain.Interfaces
{
    public interface IReceptionistRepository
    {
        Task<IEnumerable<Receptionist>> GetAllAsync();
        Task<Receptionist?> GetByIdAsync(int id);
        Task<Receptionist> AddAsync(Receptionist receptionist);
        Task<Receptionist> UpdateAsync(Receptionist receptionist);
        Task DeleteAsync(int id);
    }
}
