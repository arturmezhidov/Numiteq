using System;
using System.Linq;
using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IDataService<TEntity> : IDisposable where TEntity : BaseEntity 
    {
        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Remove(TEntity entity);

        TEntity Remove(object entityId);

        TEntity GetById(object entityId);

        IQueryable<TEntity> GetAll();
    }
}
