using System.Collections.Generic;

namespace Numiteq.ViewModels.Home
{
    public class NumberSectionViewModel
    {
        public NumberSettingsViewModel NumberSettings { get; set; }

        public IEnumerable<NumberViewModel> Numbers { get; set; }
    }
}