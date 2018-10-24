using System.ComponentModel.DataAnnotations;
using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.WhatWeDo
{
    [SettingsType(SettingsKeys.WwdBanner)]
    public class WwdBannerViewModel
    {
        [Required]
        [Display(Name = "Header")]
        public string Header { get; set; }

        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Button text")]
        public string ButtonText { get; set; }

        [Required]
        [Display(Name = "Button link")]
        public string ButtonLink { get; set; }
    }
}
