using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Numiteq.Areas.Admin.ViewModels.MainServices
{
    public class EditMainServiceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Select new image")]
        public IFormFile Image { get; set; }

        public string FileLink { get; set; }
    }
}
