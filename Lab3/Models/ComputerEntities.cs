namespace Lab3.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ComputerEntities
    {
        [Key]
        public int ComputerId { get; set; }
        public string Name { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string GraphicsCard { get; set; }

        // Foreign key for Manufacturer
        public int ManufacturerId { get; set; }

        // Navigation property
        public ManufacturerEntities Manufacturer { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
