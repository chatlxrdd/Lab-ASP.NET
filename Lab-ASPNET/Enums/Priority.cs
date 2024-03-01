using System.ComponentModel.DataAnnotations;

namespace Lab_ASPNET.Enum
{
    public enum Priority
    {
        [Display(Name = "Używane")] Used = 1,
        [Display(Name = "Nie odpakowane")] NotUsed = 2,
        [Display(Name = "Nowe")] BrandNew = 3
    }
}
