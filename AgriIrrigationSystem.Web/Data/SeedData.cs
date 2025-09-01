using AgriIrrigationSystem.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgriIrrigationSystem.Web.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // Ensure DB is created
            context.Database.Migrate();

            // Check if farms already exist
            if (context.Farms.Any())
                return;

            // Add sample data
            var farms = new List<Farm>
            {
                new Farm { Name = "Green Valley Farm", Location = "California", Size = 120.5, OwnerName = "John Doe" },
                new Farm { Name = "Sunny Acres", Location = "Texas", Size = 85.2, OwnerName = "Mary Smith" },
                new Farm { Name = "Riverbend Plantation", Location = "Florida", Size = 200.0, OwnerName = "Robert Johnson" }
            };

            context.Farms.AddRange(farms);
            context.SaveChanges();
        }
    }
}
