using Hospital.Domain.Interfaces;
using Hospital.Domain.Users.Prescriptions;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetAllAsync()
        {
            return await _context.Prescriptions.ToListAsync();
        }

        public async Task<Prescription?> GetByIdAsync(int id)
        {
            return await _context.Prescriptions.FindAsync(id);
        }

        public async Task<Prescription> AddAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        public async Task<Prescription> UpdateAsync(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Prescriptions.FindAsync(id);
            if (item != null)
            {
                _context.Prescriptions.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
