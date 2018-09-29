using System;

namespace Numiteq.DataAccess.DataContracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        void Save();
    }
}