using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Numiteq.Areas.Admin.ViewModels.Steps
{
    public class AddStepViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Icon")]
        public IFormFile Icon { get; set; }
    }
}
