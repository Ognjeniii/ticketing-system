using System.ComponentModel.DataAnnotations;

namespace ticketing_system.ViewModels.Auth
{
    public class EmailViewModel
    {
        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "You need to enter email.")]
        public string Email { get; set; }
    }
}
