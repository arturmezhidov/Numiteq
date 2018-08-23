using System;
using Numiteq.Common.Entities;

namespace Numiteq.DataAccess.DataContracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        void Save();
    }
}