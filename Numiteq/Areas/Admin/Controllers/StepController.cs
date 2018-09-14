using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Steps;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StepController : BaseController
    {
        private readonly IStepService stepService;

        public StepController(
            IServiceProvider serviceProvider,
            IStepService stepService) : base(serviceProvider)
        {
            this.stepService = stepService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Steps = stepService.GetAll().Select(ToViewModel)
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            StepSettingsViewModel vm = SettingService.GetSettings<StepSettingsViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Settings(StepSettingsViewModel vm)
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
        public IActionResult Add(AddStepViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            stepService.Add(new Step
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
            Step step = stepService.GetById(id);

            if (step == null)
            {
                return RedirectToIndex();
            }

            EditStepViewModel vm = new EditStepViewModel
            {
                Id = id,
                Title = step.Title,
                Description = step.Description,
                Icon = step.Icon
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditStepViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            stepService.Update(vm.Id, vm.Title, vm.Description, vm.Icon);

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            stepService.Remove(id);

            return RedirectToIndex();
        }

        private StepDetailViewModel ToViewModel(Step step)
        {
            return new StepDetailViewModel
            {
                Id = step.Id,
                Title = step.Title,
                Description = step.Description,
                Icon = step.Icon
            };
        }
    }
}