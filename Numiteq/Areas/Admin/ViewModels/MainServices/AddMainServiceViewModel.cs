using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Numiteq.Areas.Admin.ViewModels.MainServices
{
    public class AddMainServiceViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
    }
}
