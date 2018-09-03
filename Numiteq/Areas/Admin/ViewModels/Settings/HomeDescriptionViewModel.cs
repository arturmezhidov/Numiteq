using System.ComponentModel.DataAnnotations;
using Numiteq.Common.Settings;

namespace Numiteq.Areas.Admin.ViewModels.Settings
{
    [SettingsType(SettingsKeys.HomeDescription)]
    public class HomeDescriptionViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
