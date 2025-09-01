using AgriIrrigationSystem.Web.Models.Domain;

namespace AgriIrrigationSystem.Web.Services.Interfaces
{
    public interface IFarmService
    {
        Task<IEnumerable<Farm>> GetAllFarmsAsync();
        Task<Farm?> GetFarmByIdAsync(int id);
        Task AddFarmAsync(Farm farm);
        Task UpdateFarmAsync(Farm farm);
        Task DeleteFarmAsync(int id);
    }
}
