using Lab_ASPNET.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab_ASPNET.Models
{
    public class Computer
    //Computer - ID , Name, Processor, Memory, GraphicsCard, Manufacturer, ProductionDate, ProducerId, Producers , 
    {
        [HiddenInput]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Niepoprawna nazwa!")]
        public string Name { get; set; }

        [Display(Name = "Procesor")]
        [Required(ErrorMessage = "Niepoprawne pole procesora!")]
        public string Processor { get; set; }

        [Display(Name = "Pamięć")]
        [Required(ErrorMessage = "Niepoprawna pamiec!")]
        public string Memory { get; set; }

        [Display(Name = "Karta Graficzna")]
        [Required(ErrorMessage = "Niepoprawna nazwa karty graficznej!")]
        public string GraphicsCard { get; set; }
        [Display(Name = "Producent")]
        [Required(ErrorMessage = "Niepoprawna nazwa producenta!")]
        public string Manufacturer { get; set; }
        [Display(Name = "Data Produkcji")]
        [Required(ErrorMessage = "Niepoprawny nazwa data produkcji!")]
        public DateTime ProductionDate { get; set; }

        [Required(ErrorMessage = "Niepoprawna nazwa!")]
        public Priority Priority { get; set; }

        [HiddenInput]
        public int ProducerId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Producers { get; set; }
    }
}
