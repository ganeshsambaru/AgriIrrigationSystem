using AgriIrrigationSystem.Web.Models.Domain;

namespace AgriIrrigationSystem.Web.Repositories.Interfaces
{
    public interface IFarmRepository
    {
        Task<IEnumerable<Farm>> GetAllAsync();
        Task<Farm?> GetByIdAsync(int id);
        Task AddAsync(Farm farm);
        Task UpdateAsync(Farm farm);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
