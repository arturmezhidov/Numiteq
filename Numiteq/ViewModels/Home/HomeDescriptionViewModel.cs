using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.Home
{
    [SettingsType(SettingsKeys.HomeDescription)]
    public class HomeDescriptionViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}