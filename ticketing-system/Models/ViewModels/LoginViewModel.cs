using System.ComponentModel.DataAnnotations;

namespace ticketing_system.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required field!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required field!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
