using System.ComponentModel.DataAnnotations;
using Numiteq.Common.Settings;

namespace Numiteq.Areas.Admin.ViewModels.Number
{
    [SettingsType(SettingsKeys.Number)]
    public class NumberSettingsViewModel
    {
        [Required]
        [Display(Name = "Numbers title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Numbers description")]
        public string Description { get; set; }
    }
}