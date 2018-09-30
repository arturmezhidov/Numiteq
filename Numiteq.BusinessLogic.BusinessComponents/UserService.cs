using System.Linq;
using Microsoft.AspNetCore.Identity;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.Common.Security;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return userManager.Users;
        }

        public void AddAdminRole(string id)
        {
            ApplicationUser user = userManager.FindByIdAsync(id).Result;

            if (user != null)
            {
                if (!userManager.IsInRoleAsync(user, SystemRoles.ADMIN).Result)
                {
                    userManager.AddToRoleAsync(user, SystemRoles.ADMIN).Wait();
                }
            }
        }

        public void RemoveAdminRole(string id)
        {
            ApplicationUser user = userManager.FindByIdAsync(id).Result;

            if (user != null)
            {
                if (userManager.IsInRoleAsync(user, SystemRoles.ADMIN).Result)
                {
                    userManager.RemoveFromRoleAsync(user, SystemRoles.ADMIN).Wait();
                }
            }
        }

        public bool IsAdmin(ApplicationUser user)
        {
            return userManager.IsInRoleAsync(user, SystemRoles.ADMIN).Result;
        }
    }
}