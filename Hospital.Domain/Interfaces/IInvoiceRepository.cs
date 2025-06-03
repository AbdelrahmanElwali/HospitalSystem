using Hospital.Domain.Users.Invoices;

namespace Hospital.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice?> GetByIdAsync(int id);
        Task<Invoice> AddAsync(Invoice invoice);
        Task<Invoice> UpdateAsync(Invoice invoice);
        Task DeleteAsync(int id);
    }
}
