using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.ViewModels.Shared;
using Numiteq.ViewModels.WhatWeDo;

namespace Numiteq.Controllers
{
    public class WhatWeDoController : BaseController
    {
        private readonly IServicesService servicesService;
        private readonly IExpertiseService expertiseService;

        public WhatWeDoController(IServiceProvider serviceProvider, IServicesService servicesService, IExpertiseService expertiseService) : base(serviceProvider)
        {
            this.servicesService = servicesService;
            this.expertiseService = expertiseService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Head = GetHeadSection(),
                Services = GetServiceSection(),
                Expertises = GetExpertiseSection()
            };
            return View(vm);
        }

        private HeadSectionViewModel GetHeadSection()
        {
            WwdBannerViewModel banner = SettingService.GetSettings<WwdBannerViewModel>();
            return new HeadSectionViewModel
            {
                Title = banner.Header,
                Description = banner.Text,
                ButtonLink = banner.ButtonLink,
                ButtonText = banner.ButtonText,
                BackgroundImage = "/images/wwd.jpg"
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

        private ExpertiseSectionViewModel GetExpertiseSection()
        {
            return new ExpertiseSectionViewModel
            {
                Settings = SettingService.GetSettings<ExpertiseSettingsViewModel>(),
                Expertises = expertiseService.GetAll().Select(ToViewModel)
            };
        }

        private ServiceViewModel ToViewModel(Service service)
        {
            return new ServiceViewModel
            {
                Title = service.Title,
                Description = service.Description,
                Icon = service.Icon
            };
        }

        private ExpertiseViewModel ToViewModel(Expertise expertise)
        {
            return new ExpertiseViewModel
            {
                Title = expertise.Title,
                Description = expertise.Description,
                Icon = expertise.Icon
            };
        }
    }
}