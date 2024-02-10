namespace Lab3.Models.ViewModels
{
    public class RegisterViewModel
    {
        // Wymagane atrybuty, np. [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
