using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Lab_ASPNET.Models
{
    public class Producer
    {        
        public int Id { get; set; }
        [Required(ErrorMessage = "Uzupełnij!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Uzupełnij!")]
        public string Regon { get; set; }
        [Required(ErrorMessage = "Uzupełnij!")]
        public string Nip { get; set; }
        [Required(ErrorMessage = "Uzupełnij!")]
        public List<ComputerEntity> Computers { get; set; }
        public List<SelectListItem> Producers { get; internal set; }
    }
}


