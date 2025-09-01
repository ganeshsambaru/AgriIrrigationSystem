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
                TempData["SuccessMessage"] = "Farm created successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var farm = await _farmService.GetFarmByIdAsync(id);
            if (farm == null)
            {
                return NotFound();
            }

            var viewModel = new FarmViewModel
            {
                Id = farm.Id,
                Name = farm.Name,
                Location = farm.Location,
                Size = farm.Size,
                OwnerName = farm.OwnerName,
                CropCount = 0 // Placeholder, can fetch actual count later
            };

            return View(viewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id, string? returnUrl = null)
        {
            var farm = await _farmService.GetFarmByIdAsync(id);
            if (farm == null)
                return NotFound();

            var viewModel = new FarmViewModel
            {
                Id = farm.Id,
                Name = farm.Name,
                Location = farm.Location,
                Size = farm.Size,
                OwnerName = farm.OwnerName,
                CropCount = 0
            };

            ViewBag.ReturnUrl = returnUrl ?? Url.Action("Index", "Farm");
            return View(viewModel);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(FarmViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(model);

            var farm = await _farmService.GetFarmByIdAsync(model.Id);
            if (farm == null)
                return NotFound();

            farm.Name = model.Name;
            farm.Location = model.Location;
            farm.Size = model.Size;
            farm.OwnerName = model.OwnerName;

            await _farmService.UpdateFarmAsync(farm);
            TempData["SuccessMessage"] = "Farm updated successfully!";

            return !string.IsNullOrEmpty(returnUrl)
                ? Redirect(returnUrl)
                : RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id, string? returnUrl = null)
        {
            var farm = await _farmService.GetFarmByIdAsync(id);
            if (farm == null)
            {
                return NotFound();
            }

            var viewModel = new FarmViewModel
            {
                Id = farm.Id,
                Name = farm.Name,
                Location = farm.Location,
                Size = farm.Size,
                OwnerName = farm.OwnerName,
                CropCount = 0
            };

            // Pass return URL to view
            ViewBag.ReturnUrl = string.IsNullOrEmpty(returnUrl)
                ? Url.Action("Index")
                : returnUrl;

            return View(viewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _farmService.DeleteFarmAsync(id);
            TempData["SuccessMessage"] = "Farm deleted successfully!";
            return RedirectToAction(nameof(Index));
        }


    }
}
