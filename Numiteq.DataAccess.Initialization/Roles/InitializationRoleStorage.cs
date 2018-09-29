using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Numiteq.DataAccess.DataContracts.Initialization;
using Numiteq.DataAccess.Initialization.Data;

namespace Numiteq.DataAccess.Initialization.Roles
{
    public class InitializationRoleStorage : BaseInitializationDataStorage, IInitializationDataStorage<IdentityRole>
    {
        public List<IdentityRole> GetItems()
        {
            return Parse<IdentityRole>(InitializationData.Roles);
        }
    }
}