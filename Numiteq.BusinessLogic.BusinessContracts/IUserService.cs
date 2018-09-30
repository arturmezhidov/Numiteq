using System.Linq;
using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IUserService
    {
        IQueryable<ApplicationUser> GetAll();

        void AddAdminRole(string id);

        void RemoveAdminRole(string id);

        bool IsAdmin(ApplicationUser user);
    }
}