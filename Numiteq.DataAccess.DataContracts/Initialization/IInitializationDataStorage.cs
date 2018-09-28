using System.Collections.Generic;

namespace Numiteq.DataAccess.DataContracts.Initialization
{
    public interface IInitializationDataStorage<TEntity>
    {
        List<TEntity> GetItems();
    }
}