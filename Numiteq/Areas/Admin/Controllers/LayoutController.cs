using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Layout;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
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