using System.ComponentModel.DataAnnotations;

namespace ticketing_system.ViewModels
{
    public class ChangePassViewModel 
    {
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }
        [Display(Name = "New password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#$^+=!*()@%&]).{8,}$", 
            ErrorMessage = "Minimum length for password is 8 characters, " +
            "and must contain at least one upper case, one lower case, one special character and one number.")]
        public string NewPassword { get; set; }
        [Display(Name = "New password repeat")]
        public string RepeatedNewPassword { get; set; }

    }
}
