using AgriIrrigationSystem.Web.Models.Domain;
using AgriIrrigationSystem.Web.Repositories.Interfaces;
using AgriIrrigationSystem.Web.Services.Interfaces;

namespace AgriIrrigationSystem.Web.Services.Implementations
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;

        public FarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public async Task<IEnumerable<Farm>> GetAllFarmsAsync()
        {
            return await _farmRepository.GetAllAsync();
        }

        public async Task<Farm?> GetFarmByIdAsync(int id)
        {
            return await _farmRepository.GetByIdAsync(id);
        }

        public async Task AddFarmAsync(Farm farm)
        {
            await _farmRepository.AddAsync(farm);
            await _farmRepository.SaveChangesAsync();
        }

        public async Task UpdateFarmAsync(Farm farm)
        {
            await _farmRepository.UpdateAsync(farm);
            await _farmRepository.SaveChangesAsync();
        }

        public async Task DeleteFarmAsync(int id)
        {
            await _farmRepository.DeleteAsync(id);
            await _farmRepository.SaveChangesAsync();
        }
    }
}
