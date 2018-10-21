using System.Collections.Generic;

namespace Numiteq.ViewModels.WhatWeDo
{
    public class ServiceSectionViewModel
    {
        public ServiceSettingsViewModel Settings { get; set; }

        public IEnumerable<ServiceViewModel> Services { get; set; }
    }
}
