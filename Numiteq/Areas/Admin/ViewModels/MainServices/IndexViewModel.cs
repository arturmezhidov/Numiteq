using System.Collections.Generic;

namespace Numiteq.Areas.Admin.ViewModels.MainServices
{
    public class IndexViewModel
    {
        public IEnumerable<MainServiceDetailViewModel> MainServices { get; set; }
    }
}