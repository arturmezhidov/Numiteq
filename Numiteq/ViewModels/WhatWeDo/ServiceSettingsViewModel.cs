using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.WhatWeDo
{
    [SettingsType(SettingsKeys.Service)]
    public class ServiceSettingsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
