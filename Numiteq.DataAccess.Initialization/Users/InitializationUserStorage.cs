using System.Collections.Generic;
using Numiteq.DataAccess.DataContracts.Initialization;
using Numiteq.DataAccess.Initialization.Data;

namespace Numiteq.DataAccess.Initialization.Users
{
    public class InitializationUserStorage : BaseInitializationDataStorage, IInitializationDataStorage<User>
    {
        public List<User> GetItems()
        {
            return Parse<User>(InitializationData.Users);
        }
    }
}