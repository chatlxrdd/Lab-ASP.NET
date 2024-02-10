namespace Lab3.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ManufacturerEntities
    {
        [Key]
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        // Collection navigation property to represent the one-to-many relationship
        public ICollection<ComputerModel> Computers { get; set; }
        public int Id { get; internal set; }
    }
}
