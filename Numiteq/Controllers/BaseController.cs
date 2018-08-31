using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        protected BaseController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
    }
}
