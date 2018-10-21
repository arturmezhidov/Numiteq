using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Services;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Common.Security;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SystemRoles.ADMIN)]
    public class ServiceController : BaseController
    {
        private readonly IServicesService serviceService;

        public ServiceController(
            IServiceProvider serviceProvider,
            IServicesService serviceService) : base(serviceProvider)
        {
            this.serviceService = serviceService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Services = serviceService.GetAll().Select(ToViewModel)
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            ServiceSettingsViewModel vm = SettingService.GetSettings<ServiceSettingsViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Settings(ServiceSettingsViewModel vm)
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
        public IActionResult Add(AddServiceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            serviceService.Add(new Service
            {
                Title = vm.Title,
                Description = vm.Description,
                Icon = GetStringFromFile(vm.Icon)
            });

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Service service = serviceService.GetById(id);

            if (service == null)
            {
                return RedirectToIndex();
            }

            EditServiceViewModel vm = new EditServiceViewModel
            {
                Id = id,
                Title = service.Title,
                Description = service.Description,
                Icon = service.Icon
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditServiceViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            serviceService.Update(vm.Id, vm.Title, vm.Description, GetStringFromFile(vm.NewIcon));

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            serviceService.Remove(id);

            return RedirectToIndex();
        }

        private ServiceDetailViewModel ToViewModel(Service service)
        {
            return new ServiceDetailViewModel
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                Icon = service.Icon
            };
        }
    }
}