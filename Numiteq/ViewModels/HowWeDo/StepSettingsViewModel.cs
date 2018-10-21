using Numiteq.Common.Settings;

namespace Numiteq.ViewModels.HowWeDo
{
    [SettingsType(SettingsKeys.Step)]
    public class StepSettingsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}