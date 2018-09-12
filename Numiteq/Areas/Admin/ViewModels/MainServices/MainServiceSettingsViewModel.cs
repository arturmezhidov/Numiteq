using System.ComponentModel.DataAnnotations;
using Numiteq.Common.Settings;

namespace Numiteq.Areas.Admin.ViewModels.MainServices
{
    [SettingsType(SettingsKeys.MainService)]
    public class MainServiceSettingsViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}