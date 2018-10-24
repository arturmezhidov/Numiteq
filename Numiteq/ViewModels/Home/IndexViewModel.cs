using Numiteq.ViewModels.Shared;

namespace Numiteq.ViewModels.Home
{
    public class IndexViewModel
    {
        public HeadSectionViewModel Header { get; set; }

        public HomeDescriptionSectionViewModel HomeDescription { get; set; }

        public ServiceSectionViewModel Services { get; set; }

        public NumberSectionViewModel Numbers { get; set; }
    }
}