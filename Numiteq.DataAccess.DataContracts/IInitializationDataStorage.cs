using System.Collections.Generic;
using Numiteq.Common.Entities;

namespace Numiteq.DataAccess.DataContracts
{
    public interface IInitializationDataStorage
    {
        List<Setting> GetSettings();
    }
}
