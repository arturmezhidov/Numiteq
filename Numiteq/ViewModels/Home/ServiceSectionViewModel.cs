using System.Collections.Generic;

namespace Numiteq.ViewModels.Home
{
    public class ServiceSectionViewModel
    {
        public ServiceSettingsViewModel Settings { get; set; }

        public IEnumerable<ServiceViewModel> Services { get; set; }
    }
}