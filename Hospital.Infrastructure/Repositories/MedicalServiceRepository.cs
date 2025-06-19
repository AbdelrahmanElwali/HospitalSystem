using Hospital.Application.Interfaces;
using Hospital.Domain.Users.MedicalServices;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class MedicalServiceRepository : IMedicalServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicalServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalService>> GetAllAsync()
        {
            return await _context.MedicalServices.ToListAsync();
        }

        public async Task<MedicalService?> GetByIdAsync(Guid id)
        {
            return await _context.MedicalServices.FindAsync(id);
        }

        public async Task AddAsync(MedicalService service)
        {
            _context.MedicalServices.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MedicalService service)
        {
            _context.MedicalServices.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var service = await _context.MedicalServices.FindAsync(id);
            if (service != null)
            {
                _context.MedicalServices.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}
