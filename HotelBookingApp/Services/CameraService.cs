using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Services
{
    public class CameraService
    {
        private readonly ApplicationDbContext _context;

        public CameraService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Camera>> GetAllAsync()
        {
            return await _context.Camere.ToListAsync();
        }

        public async Task<Camera?> GetByIdAsync(Guid id)
        {
            return await _context.Camere.FindAsync(id);
        }

        public async Task CreateAsync(Camera camera)
        {
            _context.Camere.Add(camera);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Camera camera)
        {
            _context.Camere.Update(camera);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var camera = await _context.Camere.FindAsync(id);
            if (camera != null)
            {
                _context.Camere.Remove(camera);
                await _context.SaveChangesAsync();
            }
        }
    }
}
