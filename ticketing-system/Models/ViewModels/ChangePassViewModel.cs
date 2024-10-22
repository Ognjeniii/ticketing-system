using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ticketing_system.Models.ViewModels
{
    public class ChangePassViewModel /*: IValidatableObject*/
    {
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
        [Display(Name = "New password repeat")]
        public string RepeatedNewPassword { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    PropertyInfo[] properties = this.GetType().GetProperties();

        //    foreach (PropertyInfo property in properties)
        //    {
        //        var value = property.GetValue(this);
        //        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        //        {
        //            yield return new ValidationResult("All fileds are required!");
        //            yield break;
        //        }
        //    }
        //}
    }
}
