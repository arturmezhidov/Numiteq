using System.Collections.Generic;

namespace Numiteq.Areas.Admin.ViewModels.Users
{
    public class IndexViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}