using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Numiteq.Areas.Admin.ViewModels.Users;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Common.Security;
using Numiteq.Controllers;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SystemRoles.ADMIN)]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IServiceProvider serviceProvider, IUserService userService) : base(serviceProvider)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel
            {
                Users = userService.GetAll().Select(ToViewModel)
            };

            return View(vm);
        }

        public IActionResult RemoveAdminRole(string id)
        {
            userService.RemoveAdminRole(id);
            return RedirectToIndex();
        }

        public IActionResult AddAdminRole(string id)
        {
            userService.AddAdminRole(id);
            return RedirectToIndex();
        }

        protected UserViewModel ToViewModel(ApplicationUser user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                IsAdmin = userService.IsAdmin(user)
            };
        }
    }
}