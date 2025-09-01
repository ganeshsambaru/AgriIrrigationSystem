using AgriIrrigationSystem.Web.Data;
using AgriIrrigationSystem.Web.Models.Domain; // Updated namespace for Farm model
using AgriIrrigationSystem.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AgriIrrigationSystem.Web.Repositories.Implementations
{
    public class FarmRepository : IFarmRepository
    {
        private readonly AppDbContext _context;

        public FarmRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Farm>> GetAllAsync()
        {
            return await _context.Farms.ToListAsync();
        }

        public async Task<Farm?> GetByIdAsync(int id)
        {
            return await _context.Farms.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Farm farm)
        {
            await _context.Farms.AddAsync(farm);
        }

        public async Task UpdateAsync(Farm farm)
        {
            _context.Farms.Update(farm);
        }

        public async Task DeleteAsync(int id)
        {
            var farm = await GetByIdAsync(id);
            if (farm != null)
            {
                _context.Farms.Remove(farm);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
