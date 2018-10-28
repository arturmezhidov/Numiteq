using System.ComponentModel.DataAnnotations;

namespace Numiteq.ViewModels.ContactUs
{
    public class FormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Company { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
