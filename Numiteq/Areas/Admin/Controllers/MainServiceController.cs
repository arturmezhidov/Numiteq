using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.MainServices;
using Numiteq.BusinessLogic.BusinessComponents;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainServiceController : BaseController
    {
        private readonly IFileService fileService;
        private readonly IMainServicesService mainServicesService;

        public MainServiceController(
            IServiceProvider serviceProvider,
            IFileService fileService,
            IMainServicesService mainServicesService) : base(serviceProvider)
        {
            this.fileService = fileService;
            this.mainServicesService = mainServicesService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                MainServices = mainServicesService.GetAll().Select(ToViewModel)
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            MainServiceSettingsViewModel vm = SettingService.GetSettings<MainServiceSettingsViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Settings(MainServiceSettingsViewModel vm)
        {
            SettingService.SaveSettings(vm);
            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddMainServiceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mainServicesService.Add(new MainService
            {
                Title = vm.Title,
                Description = vm.Description,
                File = fileService.CreateFile(vm.Image)
            });

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MainService mainService = mainServicesService.GetById(id);

            if (mainService == null)
            {
                return RedirectToIndex();
            }

            EditMainServiceViewModel vm = new EditMainServiceViewModel
            {
                Id = id,
                Title = mainService.Title,
                Description = mainService.Description,
                FileLink = fileService.GetFileLink(mainService.File)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditMainServiceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            mainServicesService.Update(vm.Id, vm.Title, vm.Description, vm.Image);

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            mainServicesService.Remove(id);

            return RedirectToIndex();
        }

        private MainServiceDetailViewModel ToViewModel(MainService mainService)
        {
            return new MainServiceDetailViewModel
            {
                Id = mainService.Id,
                Title = mainService.Title,
                Description = mainService.Description
            };
        }
    }
}