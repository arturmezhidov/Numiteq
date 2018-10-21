using System.Collections.Generic;

namespace Numiteq.ViewModels.WhatWeDo
{
    public class ExpertiseSectionViewModel
    {
        public ExpertiseSettingsViewModel Settings { get; set; }

        public IEnumerable<ExpertiseViewModel> Expertises { get; set; }
    }
}
