namespace AgriIrrigationSystem.Web.Models.Domain
{
    public class Farm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double Size { get; set; } // in hectares
        public string OwnerName { get; set; } = string.Empty;

        public int CropCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
