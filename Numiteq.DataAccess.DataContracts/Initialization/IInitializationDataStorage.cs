using System.Collections.Generic;

namespace Numiteq.DataAccess.DataContracts.Initialization
{
    public interface IInitializationDataStorage<TEntity> where TEntity: class
    {
        List<TEntity> GetItems();
    }
}