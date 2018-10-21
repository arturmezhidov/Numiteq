using System.ComponentModel.DataAnnotations;
using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.Layout
{
    [SettingsType(SettingsKeys.Header)]
    public class HeaderViewModel
    {
        public string Link1Title { get; set; }

        public string Link1Url { get; set; }
        
        public string Link2Title { get; set; }
        
        public string Link2Url { get; set; }
        
        public string Link3Title { get; set; }
        
        public string Link3Url { get; set; }
        
        public string Link4Title { get; set; }
        
        public string Link4Url { get; set; }
        
        public string Link5Title { get; set; }
        
        public string Link5Url { get; set; }
        
        public string Link6Title { get; set; }
        
        public string Link6Url { get; set; }
        
        public string LastLinkTitle { get; set; }
        
        public string LastLinkUrl { get; set; }
    }
}
