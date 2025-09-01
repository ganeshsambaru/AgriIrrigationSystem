using System.ComponentModel.DataAnnotations;

namespace AgriIrrigationSystem.Web.Models.ViewModels
{
    public class FarmViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Farm name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Size is required")]
        [Range(0.1, 10000, ErrorMessage = "Size must be between 0.1 and 10000 hectares")]
        public double Size { get; set; }

        [Required(ErrorMessage = "Owner name is required")]
        public string OwnerName { get; set; } = string.Empty;

        public int CropCount { get; set; } = 0;

        // Computed property for displaying size with units
        public string SizeWithUnit => $"{Size} hectares";
    }
}
