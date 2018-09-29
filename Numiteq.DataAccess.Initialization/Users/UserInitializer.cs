using Microsoft.AspNetCore.Identity;
using Numiteq.Common.Entities;
using Numiteq.Common.Security;
using Numiteq.DataAccess.DataContracts;
using Numiteq.DataAccess.DataContracts.Initialization;

namespace Numiteq.DataAccess.Initialization.Users
{
    public class UserInitializer : BaseInitializer<User>, ITableInitializer
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserInitializer(IUnitOfWork context, IInitializationDataStorage<User> storage, UserManager<ApplicationUser> userManager) : base(context, storage)
        {
            this.userManager = userManager;
        }

        public void Init()
        {
            var users = Storage.GetItems();

            foreach (User user in users)
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed
                };

                var result = userManager.CreateAsync(applicationUser, user.Password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(applicationUser, SystemRoles.ADMIN).Wait();
                }
            }
        }
    }
}