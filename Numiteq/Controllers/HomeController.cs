using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Models;
using Numiteq.ViewModels.Home;

namespace Numiteq.Controllers
{
    public class HomeController : BaseController
    {
        private readonly INumberService numberService;

        public HomeController(IServiceProvider serviceProvider, INumberService numberService) : base(serviceProvider)
        {
            this.numberService = numberService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Numbers = GetNumberSection()
            };
            return View(vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private NumberSectionViewModel GetNumberSection()
        {
            return new NumberSectionViewModel
            {
                NumberSettings = SettingService.GetSettings<NumberSettingsViewModel>(),
                Numbers = numberService.GetAll().Select(ToViewModel)
            };
        }

        private NumberViewModel ToViewModel(Number number)
        {
            return new NumberViewModel
            {
                Value = number.Value,
                Label = number.Label
            };
        }
    }
}