using System.ComponentModel.DataAnnotations;
using Numiteq.Common.Settings;

namespace Numiteq.Areas.Admin.ViewModels.Layout
{
    [SettingsType(SettingsKeys.Header)]
    public class HeaderViewModel
    {
        [Display(Name = "Link title 1")]
        public string Link1Title { get; set; }

        [Display(Name = "Link url 1")]
        public string Link1Url { get; set; }

        [Display(Name = "Link title 2")]
        public string Link2Title { get; set; }

        [Display(Name = "Link url 2")]
        public string Link2Url { get; set; }

        [Display(Name = "Link title 3")]
        public string Link3Title { get; set; }

        [Display(Name = "Link url 3")]
        public string Link3Url { get; set; }

        [Display(Name = "Link title 4")]
        public string Link4Title { get; set; }

        [Display(Name = "Link url 4")]
        public string Link4Url { get; set; }

        [Display(Name = "Link title 5")]
        public string Link5Title { get; set; }

        [Display(Name = "Link url 5")]
        public string Link5Url { get; set; }

        [Display(Name = "Link title 6")]
        public string Link6Title { get; set; }

        [Display(Name = "Link url 6")]
        public string Link6Url { get; set; }

        [Display(Name = "Last link title")]
        public string LastLinkTitle { get; set; }

        [Display(Name = "Last link url")]
        public string LastLinkUrl { get; set; }
    }
}
