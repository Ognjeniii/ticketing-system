using System.ComponentModel.DataAnnotations;

namespace ticketing_system.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required field!")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required field!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
