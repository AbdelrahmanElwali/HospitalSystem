using Hospital.Domain.Interfaces;
using Hospital.Domain.Users.Receptionists;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly ApplicationDbContext _context;

        public ReceptionistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receptionist>> GetAllAsync()
        {
            return await _context.Receptionists.ToListAsync();
        }

        public async Task<Receptionist?> GetByIdAsync(int id)
        {
            return await _context.Receptionists.FindAsync(id);
        }

        public async Task<Receptionist> AddAsync(Receptionist receptionist)
        {
            _context.Receptionists.Add(receptionist);
            await _context.SaveChangesAsync();
            return receptionist;
        }

        public async Task<Receptionist> UpdateAsync(Receptionist receptionist)
        {
            _context.Receptionists.Update(receptionist);
            await _context.SaveChangesAsync();
            return receptionist;
        }

        public async Task DeleteAsync(int id)
        {
            var receptionist = await _context.Receptionists.FindAsync(id);
            if (receptionist != null)
            {
                _context.Receptionists.Remove(receptionist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
