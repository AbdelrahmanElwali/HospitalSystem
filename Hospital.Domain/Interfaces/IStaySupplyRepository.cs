using Hospital.Domain.Users.Inpatients;

namespace Hospital.Application.Interfaces
{
    public interface IStaySupplyRepository
    {
        Task<IEnumerable<StaySupply>> GetByStayIdAsync(Guid stayId);
        Task AddAsync(StaySupply supply);
        Task DeleteAsync(Guid id);
    }
}
