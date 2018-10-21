using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Expertises;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Common.Security;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SystemRoles.ADMIN)]
    public class ExpertiseController : BaseController
    {
        private readonly IExpertiseService expertiseService;

        public ExpertiseController(
            IServiceProvider serviceProvider,
            IExpertiseService expertiseService) : base(serviceProvider)
        {
            this.expertiseService = expertiseService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Expertises = expertiseService.GetAll().Select(ToViewModel)
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            ExpertiseSettingsViewModel vm = SettingService.GetSettings<ExpertiseSettingsViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Settings(ExpertiseSettingsViewModel vm)
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
        public IActionResult Add(AddExpertiseViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            expertiseService.Add(new Expertise
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
            Expertise expertise = expertiseService.GetById(id);

            if (expertise == null)
            {
                return RedirectToIndex();
            }

            EditExpertiseViewModel vm = new EditExpertiseViewModel
            {
                Id = id,
                Title = expertise.Title,
                Description = expertise.Description,
                Icon = expertise.Icon
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditExpertiseViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            expertiseService.Update(vm.Id, vm.Title, vm.Description, GetStringFromFile(vm.NewIcon));

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            expertiseService.Remove(id);

            return RedirectToIndex();
        }

        private ExpertiseDetailViewModel ToViewModel(Expertise expertise)
        {
            return new ExpertiseDetailViewModel
            {
                Id = expertise.Id,
                Title = expertise.Title,
                Description = expertise.Description,
                Icon = expertise.Icon
            };
        }
    }
}