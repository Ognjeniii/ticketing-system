using System.ComponentModel.DataAnnotations;

namespace ticketing_system.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required field!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required field!")]
        public string Password { get; set; }     
    }
}
