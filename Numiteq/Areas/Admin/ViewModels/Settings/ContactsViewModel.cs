using System.ComponentModel.DataAnnotations;
using Numiteq.Common.Settings;

namespace Numiteq.Areas.Admin.ViewModels.Settings
{
    [SettingsType(SettingsKeys.Contacts)]
    public class ContactsViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Required]
        [Display(Name = "Form Title")]
        public string FormTitle { get; set; }

        [Display(Name = "Form Description")]
        public string FormDescription { get; set; }

        [Required]
        [Display(Name = "Form Success Message")]
        public string FormSuccessMessage { get; set; }

        [Required]
        [Display(Name = "Form Error Message")]
        public string FormErrorMessage { get; set; }
    }
}
