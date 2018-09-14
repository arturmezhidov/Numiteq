using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Numiteq.BusinessLogic.BusinessContracts;

namespace Numiteq.Controllers
{
    public abstract class BaseController : Controller
    {
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

        #region Utils

        protected string GetStringFromFile(IFormFile file)
        {
            using (var binaryReader = new StreamReader(file.OpenReadStream()))
            {
                return binaryReader.ReadToEnd();
            }
        }

        #endregion
    }
}
