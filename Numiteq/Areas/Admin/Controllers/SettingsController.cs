using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Settings;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : BaseController
    {
        public SettingsController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HomeDescription()
        {
            HomeDescriptionViewModel vm = SettingService.GetSettings<HomeDescriptionViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult HomeDescription(HomeDescriptionViewModel vm)
        {
            SettingService.SaveSettings(vm);
            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult HomeWwd()
        {
            HomeWwdViewModel vm = SettingService.GetSettings<HomeWwdViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult HomeWwd(HomeWwdViewModel vm)
        {
            SettingService.SaveSettings(vm);
            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult HomeBanner()
        {
            HomeBannerViewModel vm = SettingService.GetSettings<HomeBannerViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult HomeBanner(HomeBannerViewModel vm)
        {
            SettingService.SaveSettings(vm);
            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult WwdBanner()
        {
            WwdBannerViewModel vm = SettingService.GetSettings<WwdBannerViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult WwdBanner(WwdBannerViewModel vm)
        {
            SettingService.SaveSettings(vm);
            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult HwdBanner()
        {
            HwdBannerViewModel vm = SettingService.GetSettings<HwdBannerViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult HwdBanner(HwdBannerViewModel vm)
        {
            SettingService.SaveSettings(vm);
            return RedirectToIndex();
        }
    }
}