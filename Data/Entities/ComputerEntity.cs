using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities         //Computer - ID , Name, Processor, Memory, GraphicsCard, Manufacturer, ProductionDate, ProducerId, Producers ,
{
    [Table("Computers")]
    public class ComputerEntity
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Processor { get; set; }
        [Required]
        public string Memory { get; set; }
        [Required]
        public string GraphicsCard { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public DateTime ProductionDate { get; set; }
        [Required]
        public int Priority { get; set; }
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public ProducerEntity Producer { get; set; }


    }
}
