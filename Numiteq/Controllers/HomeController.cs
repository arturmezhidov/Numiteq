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
        private readonly IMainServicesService servicesService;

        public HomeController(IServiceProvider serviceProvider, INumberService numberService, IMainServicesService servicesService) : base(serviceProvider)
        {
            this.numberService = numberService;
            this.servicesService = servicesService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Numbers = GetNumberSection(),
                Services = GetServiceSection(),
                HomeDescription = GetHomeDescriptionSection()
            };
            return View(vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private HomeDescriptionSectionViewModel GetHomeDescriptionSection()
        {
            return new HomeDescriptionSectionViewModel
            {
                HomeDescription = SettingService.GetSettings<HomeDescriptionViewModel>()
            };
        }

        private ServiceSectionViewModel GetServiceSection()
        {
            return new ServiceSectionViewModel
            {
                Settings = SettingService.GetSettings<ServiceSettingsViewModel>(),
                Services = servicesService.GetAll().Select(ToViewModel)
            };
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

        private ServiceViewModel ToViewModel(MainService service)
        {
            return new ServiceViewModel
            {
                Title = service.Title,
                Description = service.Description,
                Icon = service.Icon
            };
        }
    }
}