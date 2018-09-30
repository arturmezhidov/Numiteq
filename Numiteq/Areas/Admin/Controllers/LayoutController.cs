using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Layout;
using Numiteq.Common.Security;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SystemRoles.ADMIN)]
    public class LayoutController : BaseController
    {
        public LayoutController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Settings");
        }

        [HttpGet]
        public IActionResult Header()
        {
            HeaderViewModel vm = SettingService.GetSettings<HeaderViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Header(HeaderViewModel vm)
        {
            SettingService.SaveSettings(vm);
            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Footer()
        {
            FooterViewModel vm = SettingService.GetSettings<FooterViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Footer(FooterViewModel vm)
        {
            SettingService.SaveSettings(vm);
            return RedirectToIndex();
        }
    }
}