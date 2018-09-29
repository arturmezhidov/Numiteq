using Numiteq.DataAccess.DataContracts;
using Numiteq.DataAccess.DataContracts.Initialization;

namespace Numiteq.DataAccess.Initialization
{
    public abstract class BaseInitializer<TEntity> where TEntity: class
    {
        protected IUnitOfWork Context { get; }

        protected IInitializationDataStorage<TEntity> Storage { get; }

        protected BaseInitializer(IUnitOfWork context, IInitializationDataStorage<TEntity> storage)
        {
            Context = context;
            Storage = storage;
        }
    }
}