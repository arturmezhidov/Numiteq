using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Number;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NumberController : BaseController
    {
        private readonly INumberService numberService;

        public NumberController(IServiceProvider serviceProvider, INumberService numberService) : base(serviceProvider)
        {
            this.numberService = numberService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Numbers = numberService.GetAll().Select(ToViewModel)
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            NumberSettingsViewModel vm = SettingService.GetSettings<NumberSettingsViewModel>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Settings(NumberSettingsViewModel vm)
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
        public IActionResult Add(AddNumberViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            numberService.Add(vm.Value, vm.Label);

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Number number = numberService.GetById(id);

            if (number == null)
            {
                return RedirectToIndex();
            }

            EditNumberViewModel vm = new EditNumberViewModel
            {
                Id = id,
                Value = number.Value,
                Label = number.Label
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditNumberViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            numberService.Update(vm.Id, vm.Value, vm.Label);

            return RedirectToIndex();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            numberService.Remove(id);

            return RedirectToIndex();
        }

        private NumberDetailViewModel ToViewModel(Number number)
        {
            return new NumberDetailViewModel
            {
                Id = number.Id,
                Value = number.Value,
                Label = number.Label
            };
        }
    }
}