using System;
using System.Collections.Generic;
using System.Linq;
using Numiteq.Common.Entities;

namespace Numiteq.BusinessLogic.BusinessContracts
{
    public interface IDataService<TEntity> : IDisposable where TEntity : BaseEntity 
    {
        TEntity Add(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);

        TEntity Remove(TEntity entity);

        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);

        TEntity Remove(object entityId);

        IEnumerable<TEntity> RemoveRange(IEnumerable<object> entityIds);

        TEntity GetById(object entityId);

        IQueryable<TEntity> GetAll();
    }
}