using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Numiteq.DataAccess.DataContracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        TEntity Remove(TEntity entity);

        TEntity Remove(object entityId);

        TEntity GetById(object entityId);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}