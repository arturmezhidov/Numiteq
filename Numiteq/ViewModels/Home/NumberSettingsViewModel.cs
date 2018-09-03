using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.Home
{
    [SettingsType(SettingsKeys.Number)]
    public class NumberSettingsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}