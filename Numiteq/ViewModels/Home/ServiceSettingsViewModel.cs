using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.Home
{
    [SettingsType(SettingsKeys.MainService)]
    public class ServiceSettingsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}