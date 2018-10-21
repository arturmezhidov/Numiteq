using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.WhatWeDo
{
    [SettingsType(SettingsKeys.Expertise)]
    public class ExpertiseSettingsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}