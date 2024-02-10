namespace Lab3.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class ComputerModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę komputera.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać typ procesora.")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Proszę podać ilość pamięci RAM.")]
        [Range(1, 128, ErrorMessage = "Pamięć RAM musi być w zakresie 1-128 GB.")]
        public int Memory { get; set; }

        [Required(ErrorMessage = "Proszę podać model karty graficznej.")]
        public string GraphicsCard { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę producenta.")]
        public string Manufacturer { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę podać datę produkcji.")]
        public DateTime ProductionDate { get; set; }
    }

}
