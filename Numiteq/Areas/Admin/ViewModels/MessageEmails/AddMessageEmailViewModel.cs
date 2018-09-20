using System.ComponentModel.DataAnnotations;

namespace Numiteq.Areas.Admin.ViewModels.MessageEmails
{
    public class AddMessageEmailViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "New email")]
        public string Email { get; set; }
    }
}
