namespace Lab3.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("computers")]
    public class ComputerEntities
    {
        [Key]
        public int ComputerId { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [MaxLength(50)]
        [Required]

        public string? Processor { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Memory { get; set; }
        [MaxLength(3)]
        [Required]
        public string? GraphicsCard { get; set; }
        [MaxLength(50)]
        [Required]

        // Foreign key for Manufacturer
        public int ManufacturerId { get; set; }
        [MaxLength(50)]
        [Required]

        // Navigation property
        public ManufacturerEntities? Manufacturer { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
