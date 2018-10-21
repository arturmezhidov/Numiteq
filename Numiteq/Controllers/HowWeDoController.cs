using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.ViewModels.HowWeDo;

namespace Numiteq.Controllers
{
    public class HowWeDoController : BaseController
    {
        private readonly IStepService stepService;

        public HowWeDoController(IServiceProvider serviceProvider, IStepService stepService) : base(serviceProvider)
        {
            this.stepService = stepService;
        }

        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel
            {
                Steps = GetStepSection()
            };
            return View(vm);
        }

        private StepSectionViewModel GetStepSection()
        {
            return new StepSectionViewModel
            {
                Settings = SettingService.GetSettings<StepSettingsViewModel>(),
                Steps = stepService.GetAll().Select(ToViewModel)
            };
        }

        private StepViewModel ToViewModel(Step step)
        {
            return new StepViewModel
            {
                Title = step.Title,
                Description = step.Description,
                Icon = step.Icon
            };
        }
    }
}