using System.ComponentModel.DataAnnotations;

namespace ticketing_system.Models.ViewModels
{
    public class EmailViewModel
    {
        [EmailAddress]
        public string? Email { get; set; }
    }
}
