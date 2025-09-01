using AgriIrrigationSystem.Web.Models.Domain;
using AgriIrrigationSystem.Web.Models.ViewModels;
using AgriIrrigationSystem.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgriIrrigationSystem.Web.Controllers
{
    public class FarmController : Controller
    {
        private readonly IFarmService _farmService;

        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        // List all farms
        public async Task<IActionResult> Index()
        {
            var farms = await _farmService.GetAllFarmsAsync();

            // Convert Domain models to ViewModels
            var farmViewModels = farms.Select(f => new FarmViewModel
            {
                Id = f.Id,
                Name = f.Name,
                Location = f.Location,
                Size = f.Size,
                OwnerName = f.OwnerName,
                CropCount = f.CropCount
            }).ToList();

            return View(farmViewModels);
        }
    

        // GET: Farm/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmViewModel model)
        {
            if (ModelState.IsValid)
            {
                var farm = new Farm
                {
                    Name = model.Name,
                    Location = model.Location,
                    Size = model.Size,
                    OwnerName = model.OwnerName,
                    CropCount = 0, // Always default to zero
                    CreatedAt = DateTime.Now
                };

                await _farmService.AddFarmAsync(farm);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
