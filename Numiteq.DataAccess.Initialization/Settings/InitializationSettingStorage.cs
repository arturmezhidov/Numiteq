using System.Collections.Generic;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts.Initialization;
using Numiteq.DataAccess.Initialization.Data;

namespace Numiteq.DataAccess.Initialization.Settings
{
    public class InitializationSettingStorage : BaseInitializationDataStorage, IInitializationDataStorage<Setting>
    {
        public List<Setting> GetItems()
        {
            return Parse<Setting>(InitializationData.Settings);
        }
    }
}