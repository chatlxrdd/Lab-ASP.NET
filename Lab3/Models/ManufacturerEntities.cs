namespace Lab3.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("manufactuer")]
    public class ManufacturerEntities
    {
        [Key]
        public int ManufacturerId { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }
        [MaxLength(50)]
        [Required]

        // Collection navigation property to represent the one-to-many relationship
        public ICollection<ComputerModel>? Computers { get; set; }
        public int Id { get; internal set; }

    }
}
