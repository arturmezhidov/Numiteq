using System.Collections.Generic;

namespace Numiteq.Areas.Admin.ViewModels.Services
{
    public class IndexViewModel
    {
        public IEnumerable<ServiceDetailViewModel> Services { get; set; }
    }
}