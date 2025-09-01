using Microsoft.EntityFrameworkCore;
using AgriIrrigationSystem.Web.Models.Domain;

namespace AgriIrrigationSystem.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Farm> Farms { get; set; }
        //public DbSet<Crop> Crops { get; set; }
        //public DbSet<Sensor> Sensors { get; set; }
    }
}
