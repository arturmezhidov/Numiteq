using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.ViewModels.Layout;

namespace Numiteq.Controllers
{
    public abstract class BaseController : Controller
    {
        private const string layoutDataKey = "LayoutData";
        private ISettingService settingService;

        protected IServiceProvider ServiceProvider { get; }
        protected ISettingService SettingService => settingService ?? (settingService = ServiceProvider.GetRequiredService<ISettingService>());

        protected virtual string IndexActionName => "Index";

        protected BaseController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        protected IActionResult RedirectToIndex(string error = null)
        {
            return RedirectToAction(IndexActionName);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            LayoutViewModel vm = new LayoutViewModel
            {
                Header = SettingService.GetSettings<HeaderViewModel>(),
                Footer = SettingService.GetSettings<FooterViewModel>()
            };
            ViewData.Add(layoutDataKey, vm);
        }

        #region Utils

        protected string GetStringFromFile(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                return null;
            }

            using (var binaryReader = new StreamReader(file.OpenReadStream()))
            {
                return binaryReader.ReadToEnd();
            }
        }

        #endregion
    }
}
