using System.Collections.Generic;

namespace Numiteq.ViewModels.HowWeDo
{
    public class StepSectionViewModel
    {
        public StepSettingsViewModel Settings { get; set; }

        public IEnumerable<StepViewModel> Steps { get; set; }
    }
}