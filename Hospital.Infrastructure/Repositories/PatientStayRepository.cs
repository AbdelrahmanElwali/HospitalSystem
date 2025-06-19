using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Inpatients;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class PatientStayRepository : IPatientStayRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientStayRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientStay>> GetAllAsync()
        {
            return await _context.PatientStays.ToListAsync();
        }

        public async Task<PatientStay?> GetByIdAsync(Guid id)
        {
            return await _context.PatientStays.FindAsync(id);
        }

        public async Task AddAsync(PatientStay stay)
        {
            _context.PatientStays.Add(stay);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PatientStay stay)
        {
            _context.PatientStays.Update(stay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var stay = await _context.PatientStays.FindAsync(id);
            if (stay != null)
            {
                _context.PatientStays.Remove(stay);
                await _context.SaveChangesAsync();
            }
        }
    }
}
