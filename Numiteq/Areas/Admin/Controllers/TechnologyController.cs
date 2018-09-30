using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Common.Security;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SystemRoles.ADMIN)]
    public class TechnologyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}