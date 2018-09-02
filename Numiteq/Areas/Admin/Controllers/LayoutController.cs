﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Settings;
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
            return View();
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
            return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }
    }
}